
/* ----------------- Start Document ----------------- */


(function($){
    "use strict";
	$(document).ready(function(){

/* 00 Preloader
================================================== */
	/*$(window).load(function() { // makes sure the whole site is loaded
		"use strict";
			$('.ring').fadeOut(); // will first fade out the loading animation
			$('.loader').delay(10).fadeOut('slow'); // will fade out the white DIV that covers the website.
			$('#main_slider').delay(10).css({'overflow':'visible'});
		})	*/


jQuery('#camera_wrap_3').camera({
				height: '50%',
				pagination: false,
				thumbnails: true,
				imagePath: '../images/'
			});

    

/* 
================================================== */

	jQuery('#recent-blog').showbizpro({
		dragAndScroll: "on",
		visibleElementsArray:[0],
		carousel:"off",
		entrySizeOffset:0,
		allEntryAtOnce:"off"
	});

/* 
================================================== */

	jQuery('#shining-stars').showbizpro({
		dragAndScroll:"off",
		visibleElementsArray:[1,1,1,1],
		carousel:"off",
		entrySizeOffset:0,
		allEntryAtOnce:"off",
		speed:1000,
		autoPlay:"on",
		rewindFromEnd:"on",
		delay:8000
	});

	jQuery('#recent-work').showbizpro({
		dragAndScroll: "off",
		visibleElementsArray:[6,4,3,1],
		carousel:"on",
		entrySizeOffset:1,
		allEntryAtOnce:"off"
	});
	
var isMobile = false;

/* Mobile Detect
================================================== */

            if (navigator.userAgent.match(/Android/i) || 
                navigator.userAgent.match(/webOS/i) ||
                navigator.userAgent.match(/iPhone/i) || 
                navigator.userAgent.match(/iPad/i)|| 
                navigator.userAgent.match(/iPod/i) || 
                navigator.userAgent.match(/BlackBerry/i)) {                 
                isMobile = true;            
            }


/*
================================================== */


            if (isMobile == false) {
                $('*[data-animated]').addClass('animated');
            }
            

            function animated_contents() {
                $(".animated:appeared").each(function (i) {
                    var $this    = $(this),
                        animated = $(this).data('animated');

                    setTimeout(function () {
                        $this.addClass(animated);
                    }, 100 * i);

                    $('.progress-bar .bar').each(function (i) {
                        var pogresBar = $this.data('width');
                        $this.css({'width' : pogresBar});
                    });
                });
            }
            
            animated_contents();
            $(window).scroll(function () {
                animated_contents();
            });



/* ------------------ End Document ------------------ */
});
	


})(this.jQuery);