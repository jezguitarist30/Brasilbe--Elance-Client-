// PAGE LOADING ANIMATION
if (navigator.userAgent.match(/MSIE\s(?!9.0)/) && navigator.userAgent.match(/MSIE\s(?!10.0)/)) {
}
else {
    $(document).ready(function () {
        $("body").queryLoader2({
            barColor: "#fff",
            backgroundColor: "#000",
            percentage: true,
            barHeight: 5,
            completeAnimation: "grow",
            minimumTime: 100
        });
    });
}
// JQUERY ASCENSOR SETTINGS

$('#ascensorBuilding').ascensor({
    AscensorName: 'ascensor',
    ChildType: 'section',
    AscensorFloorName: 'Home | About',
    Time: 1000,
    WindowsOn: 1,
    Direction: 'chocolate',
    AscensorMap: '1|1 & 2|1',
    Easing: 'easeInOutQuad',
    KeyNavigation: true
});



// REGISTER & LOGIN FORM

$(window).load(function () {
    //the form wrapper (includes all forms)
    var $form_wrapper = $('#form_wrapper'),
    //the current form is the one with class active
					$currentForm = $form_wrapper.children('form.active'),
    //the change form links
					$linkform = $form_wrapper.find('.linkform');

    //get width and height of each form and store them for later						
    $form_wrapper.children('form').each(function (i) {
        var $theForm = $(this);
        //solve the inline display none problem when using fadeIn fadeOut
        if (!$theForm.hasClass('active'))
            $theForm.hide();
        $theForm.data({
            width: $theForm.width(),
            height: $theForm.height() + 10
        });
    });

    //set width and height of wrapper (same of current form)
    setWrapperWidth();

    /*
    clicking a link (change form event) in the form
    makes the current form hide.
    The wrapper animates its width and height to the 
    width and height of the new current form.
    After the animation, the new form is shown
    */
    $linkform.bind('click', function (e) {
        var $link = $(this);
        var target = $link.attr('data-rel');
        $currentForm.fadeOut(400, function () {
            //remove class active from current form
            $currentForm.removeClass('active');
            //new current form
            $currentForm = $form_wrapper.children('form.' + target);
            //animate the wrapper
            $form_wrapper.stop()
									 .animate({
									     width: $currentForm.data('width') + 'px',
									     height: $currentForm.data('height') + 'px'
									 }, 500, function () {
									     //new form gets class active
									     $currentForm.addClass('active');
									     //show the new form
									     $currentForm.fadeIn(400);
									 });
        });
        e.preventDefault();
    });

    function setWrapperWidth() {
        $form_wrapper.css({
            width: $currentForm.data('width') + 'px',
            height: $currentForm.data('height') + 'px'
        });
    }

    /*
    for the demo we disabled the submit buttons
    if you submit the form, you need to check the 
    which form was submited, and give the class active 
    to the form you want to show
    */
    $form_wrapper.find('input[type="submit"]')
							 .click(function (e) {
							     e.preventDefault();
							 });
				});

				// CENTER THE REGISTER FORM VERTICALLY

				function getWindowHeight() {

				    var windowHeight = 0;
				    if (typeof (window.innerHeight) == 'number') {
				        windowHeight = window.innerHeight;
				    }
				    else {
				        if (document.documentElement && document.documentElement.clientHeight) {
				            windowHeight = document.documentElement.clientHeight;
				        }
				        else {
				            if (document.body && document.body.clientHeight) {
				                windowHeight = document.body.clientHeight;
				            }
				        }
				    }
				    return windowHeight;
				}

				function setContent() {
				    if (document.getElementById) {
				        var windowHeight = getWindowHeight();
				        if (windowHeight > 0) {
				            var contentElement = document.getElementById('middle');
				            var contentHeight = contentElement.offsetHeight;
				            if (windowHeight - contentHeight > 0) {
				                contentElement.style.position = 'absolute';
				                contentElement.style.top = ((windowHeight / 2) - (contentHeight / 2)) + 'px';
				            }
				            else {
				                contentElement.style.position = 'absolute';
				            }
				        }
				    }
				}
				window.onload = function () {
				    setContent();
				}
				window.onresize = function () {
				    setContent();
				}

/////////////////* ACCORDION */////////////////////////

				$(window).load(function () {
				    $("#accordion").accordion();
				});

/////////////////* TESTIMONIALS */////////////////////////

				$(window).load(function () {

				    $('blockquote').quovolver();

				});

//Scrollbar Settings

				(function ($) {
				    $(window).load(function () {
				        $("#scrollbar").mCustomScrollbar({
				            set_width: false, /*optional element width: boolean, pixels, percentage*/
				            set_height: '100%', /*optional element height: boolean, pixels, percentage*/
				            horizontalScroll: false, /*scroll horizontally: boolean*/
				            scrollInertia: 550, /*scrolling inertia: integer (milliseconds)*/
				            scrollEasing: "easeOutCirc", /*scrolling easing: string*/
				            mouseWheel: "pixels", /*mousewheel support and velocity: boolean, "auto", integer, "pixels"*/
				            mouseWheelPixels: 60, /*mousewheel pixels amount: integer*/
				            autoDraggerLength: true, /*auto-adjust scrollbar dragger length: boolean*/
				            scrollButtons: { /*scroll buttons*/
				                enable: false, /*scroll buttons support: boolean*/
				                scrollType: "continuous", /*scroll buttons scrolling type: "continuous", "pixels"*/
				                scrollSpeed: 20, /*scroll buttons continuous scrolling speed: integer*/
				                scrollAmount: 40 /*scroll buttons pixels scroll amount: integer (pixels)*/
				            },
				            advanced: {
				                updateOnBrowserResize: true, /*update scrollbars on browser resize (for layouts based on percentages): boolean*/
				                updateOnContentResize: false, /*auto-update scrollbars on content resize (for dynamic content): boolean*/
				                autoExpandHorizontalScroll: false, /*auto expand width for horizontal scrolling: boolean*/
				                autoScrollOnFocus: true /*auto-scroll on focused elements: boolean*/
				            },
				            callbacks: {
				                onScrollStart: function () { }, /*user custom callback function on scroll start event*/
				                onScroll: function () { }, /*user custom callback function on scroll event*/
				                onTotalScroll: function () { }, /*user custom callback function on scroll end reached event*/
				                onTotalScrollBack: function () { }, /*user custom callback function on scroll begin reached event*/
				                onTotalScrollOffset: 0, /*scroll end reached offset: integer (pixels)*/
				                whileScrolling: false, /*user custom callback function on scrolling event*/
				                whileScrollingInterval: 30 /*interval for calling whileScrolling callback: integer (milliseconds)*/
				            }
				        });
				    });
				})(jQuery);

				//IE placeholder fix

				$(function () {
				    $('input, textarea').placeholder();
				});

				// JQUERY SLABTEXT SETTINGS
				function slabTextHeadlines() {
				    $(".slogan").slabText({
				        // Don't slabtext the headers if the viewport is under 640px
				        "viewportBreakpoint": 640
				    });
				};
				$(window).load(function () {
				    setTimeout(slabTextHeadlines, 100);
				});