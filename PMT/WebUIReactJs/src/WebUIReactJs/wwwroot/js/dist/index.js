(function() {
    'use strict';

    $(function() {

        var config = $.localStorage.get('config');
        $('body').attr('data-layout', config.layout);
        $('body').attr('data-palette', config.theme);
        $('body').attr('data-direction', config.direction);
        var colors = config.colors;
        var palette = config.palette;

        //$('button[data-animate]').on('click', function() {
        //    var id = $(this).data('animate');
        //    animateButton('#' + id);
        //});

    });

})();
