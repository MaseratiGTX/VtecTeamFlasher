(function( $ ) {

	function createShiftArr(step, linebreak) {
		var space = '    ';

		if ( isNaN(parseInt(step)) ) {
			space = step;
		} else {
			space = new Array(step + 1).join(' ');
		}

		var shift = [linebreak];

		for(var ix=0;ix<100;ix++){
			shift.push(shift[ix]+space);
		}

		return shift;
	};


	function replaceAll(source, oldValue, newValue) {
	    return source.replace(new RegExp(RegExpHelper.EscapeRegExp(oldValue), 'g'), newValue);
	};



	var XMLFormatter = function (options) {
		this.init(options);

        this.xmlformat = function(text) {
			return this.xml.call(this, text);
		};
	};


	XMLFormatter.prototype = {
		options: {},

		init: function(options) {
			this.options = $.extend({}, $.fn.xmlformat.defaults, options);
			this.step = this.options.step;
			this.linebreak = this.options.linebreak;
		    this.lt = this.options.lt;
		    this.gt = this.options.gt;
			this.preserveComments = this.options.preserveComments;
			this.shift = createShiftArr(this.step, this.linebreak);
		},

		xml: function(text) {
			var ar = text.replace(/>\s{0,}</g,"><")
						 .replace(/</g,"~::~<")
						 .replace(/\s*xmlns\:/g,"~::~xmlns:")
						 .replace(/\s*xmlns\=/g,"~::~xmlns=")
						 .split('~::~'),
				len = ar.length,
				inComment = false,
				deep = 0,
				str = '',
				ix = 0;

		    for (ix = 0; ix < len; ix++) {
				// start comment or <![CDATA[...]]> or <!DOCTYPE //
				if(ar[ix].search(/<!/) > -1) {
				    str += this.shift[deep] + this.FIX_LTGT(ar[ix]);
					inComment = true;
					// end comment  or <![CDATA[...]]> //
					if(ar[ix].search(/-->/) > -1 || ar[ix].search(/\]>/) > -1 || ar[ix].search(/!DOCTYPE/) > -1 ) {
						inComment = false;
					}
				} else
				// end comment  or <![CDATA[...]]> //
				if(ar[ix].search(/-->/) > -1 || ar[ix].search(/\]>/) > -1) {
                    str += this.FIX_LTGT(ar[ix]);
					inComment = false;
				} else
				// <elm></elm> //
				if( /^<\w/.exec(ar[ix-1]) && /^<\/\w/.exec(ar[ix]) && /^<[\w:\-\.\,]+/.exec(ar[ix-1]) == /^<\/[\w:\-\.\,]+/.exec(ar[ix])[0].replace('/','')) {
	                str += this.FIX_LTGT(ar[ix]);
					if(!inComment) deep--;
				} else
				 // <elm> //
				if(ar[ix].search(/<\w/) > -1 && ar[ix].search(/<\//) == -1 && ar[ix].search(/\/>/) == -1 ) {
				    str = !inComment ? str += this.shift[deep++] + this.FIX_LTGT(ar[ix]) : str += this.FIX_LTGT(ar[ix]);
				} else
				 // <elm>...</elm> //
				if(ar[ix].search(/<\w/) > -1 && ar[ix].search(/<\//) > -1) {
				    str = !inComment ? str += this.shift[deep] + this.FIX_LTGT(ar[ix]) : str += this.FIX_LTGT(ar[ix]);
				} else
				// </elm> //
				if(ar[ix].search(/<\//) > -1) {
				    str = !inComment ? str += this.shift[--deep] + this.FIX_LTGT(ar[ix]) : str += this.FIX_LTGT(ar[ix]);
				} else
				// <elm/> //
				if(ar[ix].search(/\/>/) > -1 ) {
				    str = !inComment ? str += this.shift[deep] + this.FIX_LTGT(ar[ix]) : str += this.FIX_LTGT(ar[ix]);
				} else
				// <? xml ... ?> //
				if(ar[ix].search(/<\?/) > -1) {
				    str += this.shift[deep] + this.FIX_LTGT(ar[ix]);
				} else
				// xmlns //
				if( ar[ix].search(/xmlns\:/) > -1  || ar[ix].search(/xmlns\=/) > -1) {
				    str += this.shift[deep] + ar[ix];
				}
                // OTHERS //
				else {
					str += ar[ix];
				}
			}

			return  (str.indexOf(this.linebreak) === 0) ? str.substring(this.linebreak.length) : str;
		},

        
        FIX_LTGT: function(source) {
            return replaceAll(replaceAll(source, '<', this.lt), '>', this.gt);
	    }
	};


	$.fn.xmlformat = function(options) {
		var fmt = new XMLFormatter(options);
		return this.each(function() {
			var node = $(this);
			var text = node.val();
			text = fmt.xmlformat(text);
			node.val(text);
		});
	};

	$.xmlformat = function(text, options) {
		var fmt = new XMLFormatter(options);
		return fmt.xmlformat(text);
	};

	$.fn.xmlformat.defaults = {
		step: '    ',
		linebreak: '\n',
		lt: '<',
        gt: '>',
		preserveComments: false
	};


})(jQuery);

