"use strict";
var gulp = require('gulp');
var connect = require('gulp-connect'); //Runs a local dev server
var open = require('gulp-open'); //Open a URL in a web browser
var browserify = require('browserify'); // Bundles JS
var reactify = require('reactify');  // Transforms React JSX to JS
var source = require('vinyl-source-stream'); // Use conventional text streams with Gulp
var concat = require('gulp-concat'); //Concatenates files
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
gulp.task('production', ['html', 'js', 'css', 'images', 'lib', 'bundle']);