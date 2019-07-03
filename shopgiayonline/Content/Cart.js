jQuery(function ($) {


    /* ----------------------------------------------------------- */
    /*  1. CARTBOX 
    /* ----------------------------------------------------------- */

    jQuery(".aa-cartbox").hover(function () {
        jQuery(this).find("div.aa-cartbox-summary").fadeIn(500);
    }
        , function () {
            jQuery(this).find("div.aa-cartbox-summary").fadeOut(500);
        }
    );
});