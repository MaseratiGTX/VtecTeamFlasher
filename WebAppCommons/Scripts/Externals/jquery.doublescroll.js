jQuery.fn.doubleScroll = function(userOptions) {
    // Default options
    var options = {
        scrollCss: {
            'overflow-x': $.browser.msie && $.browser.version == '8.0' ? 'scroll' : 'auto',
            'overflow-y': 'hidden'
        },
        scrollPaddings: {
            top: '5px',
            bottom: '5px'
        },
    };
    $.extend(true, options, userOptions);
    // do not modify
    // internal stuff
    $.extend(options, {
        scrollBarMarkup: '<div class="doubleScroll-scroll-wrapper"><div class="doubleScroll-scroll"></div></div>',
        scrollBarInnerSelector: '.doubleScroll-scroll'
    });


    var _showScrollBar = function($self, options) {
        
        // restore previously added scrolls
        var $topScrollBar = $self.prev('div.doubleScroll-scroll-wrapper');
        var $bottomScrollBar = $self.next('div.doubleScroll-scroll-wrapper');

        if ($self.scrollWidth() <= $self.width()) {
            // content doesn't scroll - remove scrolls
            $topScrollBar.remove();
            $bottomScrollBar.remove();
            $self.hasDoubleScroll = false;
            return;
        }

        if($self.hasDoubleScroll) {
            // nothing to change - return
            return;
        }
        
        $self.hasDoubleScroll = true;

        // add top & bottom divs that will act as an upper & bottom scroll
        $topScrollBar = $(options.scrollBarMarkup).insertBefore($self);
        $bottomScrollBar = $(options.scrollBarMarkup).insertAfter($self);

        // bind upper scroll to scroll $self & bottom scroll
        $topScrollBar.bind('scroll.doubleScroll', function() {
            $self.scrollLeft($topScrollBar.scrollLeft());
            $bottomScrollBar.scrollLeft($topScrollBar.scrollLeft());
        });

        // bind bottom scroll to scroll $self & upper scroll
        $bottomScrollBar.bind('scroll.doubleScroll', function() {
            $self.scrollLeft($bottomScrollBar.scrollLeft());
            $topScrollBar.scrollLeft($bottomScrollBar.scrollLeft());
        });


        // margin & padding calculations
        var scrollbarWidth = $.scrollbarWidth();

        var selfScrollWidth = $self.scrollWidth();
        
        var scrollPaddingTop = parseInt(options.scrollPaddings.top, 10) || 0; 
        var selfMarginTop = parseInt($self.css('marginTop'), 10) || 0;
        var selfPaddingTop = parseInt($self.css('paddingTop'), 10) || 0;
        var selfIndentsTop = selfMarginTop + selfPaddingTop;
       
        var topScrollMarginTop = selfMarginTop + selfPaddingTop;
        var topScrollMarginBottom = scrollPaddingTop - selfIndentsTop;

        var scrollPaddingBottom = parseInt(options.scrollPaddings.bottom, 10) || 0; 
        var selfPaddingBottom = parseInt($self.css('paddingBottom'), 10) || 0;
        var selfMarginBottom = parseInt($self.css('marginBottom'), 10) || 0;
        var selfIndentsBottom = selfMarginBottom + selfPaddingBottom;
       
        var bottomScrollMarginTop = scrollPaddingBottom - selfIndentsBottom;
        var bottomScrollMarginBottom = selfMarginBottom + selfPaddingBottom;

        // set margins and paddings of the wrappers
        $topScrollBar.css('marginTop', topScrollMarginTop);
        $topScrollBar.css('marginBottom', topScrollMarginBottom);
        $bottomScrollBar.css('marginTop', bottomScrollMarginTop);
        $bottomScrollBar.css('marginBottom', bottomScrollMarginBottom);

        // scroll css applying
        $topScrollBar.css(options.scrollCss);
        $bottomScrollBar.css(options.scrollCss);

        // set size of the wrappers
        $topScrollBar
            .height(scrollbarWidth)
            .width('100%');
        $(options.scrollBarInnerSelector, $topScrollBar)
            .height(scrollbarWidth)
            .width(selfScrollWidth);
        $bottomScrollBar
            .height(scrollbarWidth)
            .width('100%');
        $(options.scrollBarInnerSelector, $bottomScrollBar)
            .height(scrollbarWidth)
            .width(selfScrollWidth);

        // Fix: Copying position from the bottom scrollbar
        $topScrollBar.scrollLeft($self.scrollLeft());
        $bottomScrollBar.scrollLeft($self.scrollLeft());
    };

    return this.each(function() {
        var $self = $(this);

        $self.redrawScrollBars = function() {
            _showScrollBar($self, options);
        };

        DblScrollHelper.registerElement($self);

        $self.redrawScrollBars();
    });
};


DblScrollHelper = {    
    elements: new Array(),

    registerElement: function(element) {
        this.elements[this.elements.length] = element;
    },

    initialize: function () {
        $('.dblScroll').doubleScroll();    
    },

    redrawScrollBars: function() {
        for (var index = 0; index < this.elements.length; index++) {
            this.elements[index].redrawScrollBars();
        }
    },    
};

function DblScrollHelper_RedrawScrollBars() {
    DblScrollHelper.redrawScrollBars();
}