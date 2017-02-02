if (window.app.mode === 'DEV') {
    //App base libs
    document.write('<script src="js/utils.js"><\/script>');
    document.write('<script src="js/services.js"><\/script>');
    document.write('<script src="js/notification.js"><\/script>');
    document.write('<script src="js/progress.js"><\/script>');
    document.write('<script src="js/cache.js"><\/script>');
    document.write('<script src="js/bundle.js"><\/script>');
} else {
    document.write('<script src="js/scripts.min.js"><\/script>');
}