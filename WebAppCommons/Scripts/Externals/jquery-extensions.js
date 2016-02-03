(
    function($) {
        $.styles = {
            insertRule: function(selector, rules, contxt) {
                var context = contxt || document, stylesheet;

                if (typeof context.styleSheets == 'object') {
                    if (context.styleSheets.length) {
                        stylesheet = context.styleSheets[context.styleSheets.length - 1];
                    }
                    if (context.styleSheets.length) {
                        if (context.createStyleSheet) {
                            stylesheet = context.createStyleSheet();
                        } else {
                            context.getElementsByTagName('head')[0].appendChild(context.createElement('style'));
                            stylesheet = context.styleSheets[context.styleSheets.length - 1];
                        }
                    }
                    if (stylesheet.addRule) {
                        for (var i = 0; i < selector.length; ++i) {
                            stylesheet.addRule(selector[i], rules);
                        }
                    } else {
                        stylesheet.insertRule(selector.join(',') + '{' + rules + '}', stylesheet.cssRules.length);
                    }
                }
            }
        };
    }
)(jQuery);


(function ($, undefined, width) {

    $.scrollbarWidth = function () {
        var parent, child;

        if (width === undefined) {
            parent = $('<div style="width:50px;height:50px;overflow:auto;position:absolute;top:-300px;left:-300px;"><div></div></div>').appendTo('body');
            child = parent.children();
            width = child.innerWidth() - child.height("60px").innerWidth();
            parent.remove();
        }

        return width;
    };

})(jQuery);


(
    function ($) {
        $.fn.extend({
            
            scrollWidth: function() {
                return this[0].scrollWidth;
            },


            AggregateCss: function (names) {
                if (this.length != 1) return NaN;

                if (this[0] === undefined) return NaN;
                if (this[0] == document) return 0;

                var result = this.parent().AggregateCss(names);

                for (var index = 0; index < names.length; index++) {
                    result += (parseInt(this.css(names[index]), 10) || 0);
                }

                return result;
            },

            ConsideringBaseElement: function (baseElement) {

                if (baseElement instanceof jQuery) {
                    this.BaseElement = baseElement;
                } else {
                    this.BaseElement = $(baseElement);
                }

                return this;
            },

            CalculateMinHeightToFitWindow: function () {
                if (this.BaseElement === undefined) return NaN;

                            
                var baseElementRequiredHeight = $(window).height() - this.BaseElement.AggregateCss(
                    ["marginTop", "borderTopWidth", "paddingTop", "paddingBottom", "borderBottomWidth", "marginBottom"]
                );
                
                var baseElementHeight = this.BaseElement.height();
                var thisElementHeight = this.height();
                var otherControlsHeight = baseElementHeight - thisElementHeight;
                
                var result = baseElementRequiredHeight - otherControlsHeight;
                
                return result >= 0 ? result : NaN;
            },

            StretchToFitWindow: function (minPossibleHeight) {
                if (this.BaseElement === undefined) return this;


                var minHeight = this.CalculateMinHeightToFitWindow(minPossibleHeight);

                if (minHeight === NaN) return this;

                if (minPossibleHeight !== undefined) {
                    minHeight = minHeight < minPossibleHeight ? minPossibleHeight : minHeight;
                }


                this.css("min-height", minHeight + "px");


                return this;
            },


            form: function () {
                return this.parents("form:first");
            },

            setParameter: function (name, value) {
                $(

                    this.find("input[type='hidden'][name='" + name + "']:first").get(0)
                    ||
                    $('<input>').attr({ type: 'hidden', id: name, name: name }).appendTo(this)[0]

                ).val(value);
            }
        });
    }
)(jQuery);