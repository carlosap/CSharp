"use strict";
var gulp = require('gulp');
var connect = require('gulp-connect'); //Runs a local dev server
var open = require('gulp-open'); //Open a URL in a web browser
var concat = require('gulp-concat'); //Concatenates files
var rename = require('gulp-rename');
var uglify = require('gulp-uglify');
var htmlmin = require('gulp-html-minifier'); //Minifies HTML
var config = {
	port: 9000,
	devBaseUrl: 'http://localhost',
	paths: {
		html: './app/*.html',
		js: './app/js/**/*',
		images: './app/images/*',
		css: './app/css/**/*',
		lib: './app/lib/**/*',
		dist: './wwwroot',
		mainJs: './app/*bundle*'
	}
}

gulp.task('connect', function() {
	connect.server({
		root: ['app'],
		port: config.port,
		base: config.devBaseUrl,
		livereload: true
	});
});

gulp.task('open', ['connect'], function() {
	gulp.src('app/index.html')
		.pipe(open({ uri: config.devBaseUrl + ':' + config.port + '/'}));
});

gulp.task('html', function() {
    gulp.src(config.paths.html)
        .pipe(htmlmin({ collapseWhitespace: true }))
		.pipe(gulp.dest(config.paths.dist))
		.pipe(connect.reload());
});

gulp.task('bundle', function () {
    gulp.src(config.paths.mainJs)
		.pipe(gulp.dest(config.paths.dist))
		.pipe(connect.reload());
});

gulp.task('js', function () {
    gulp.src(config.paths.js)
        .pipe(gulp.dest(config.paths.dist + '/js'))
        .pipe(connect.reload());
});

gulp.task('scripts', function () {
    return gulp.src([
        './app/js/utils.js',
        './app/js/services.js',
        './app/js/notification.js',
        './app/js/notification.js',
        './app/js/progress.js',
        './app/js/cache.js',
        './app/js/bundle.js'])
      .pipe(concat('scripts.js'))     
      .pipe(gulp.dest(config.paths.dist + '/js'))
      .pipe(rename('scripts.min.js'))
      .pipe(uglify())
      .pipe(gulp.dest(config.paths.dist + '/js'));
});

gulp.task('css', function () {
    gulp.src(config.paths.css)
        .pipe(gulp.dest(config.paths.dist + '/css'))
        .pipe(connect.reload());
});

gulp.task('images', function () {
    gulp.src(config.paths.images)
        .pipe(gulp.dest(config.paths.dist + '/images'))
        .pipe(connect.reload());
});
gulp.task('lib', function () {
    gulp.src(config.paths.lib)
        .pipe(gulp.dest(config.paths.dist + '/lib'))
        .pipe(connect.reload());

});
gulp.task('watch', function() {
	gulp.watch(config.paths.html, ['html']);
	gulp.watch(config.paths.js, ['js']);
});

gulp.task('default', ['html', 'js', 'css', 'images', 'lib', , 'bundle', 'open', 'watch']);
gulp.task('prod', ['html', 'js', 'css', 'images', 'lib', 'bundle', 'scripts']);