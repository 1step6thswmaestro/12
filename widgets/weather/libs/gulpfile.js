var gulp = require('gulp');
var uglify = require('gulp-uglify');
var buffer = require('vinyl-buffer');

var browserify = require('browserify');
var source = require('vinyl-source-stream');


gulp.task('build-min-js', function() {
    return browserify('./lib/Flowing.js')
        .bundle()
        .pipe(source('Flowing.min.js'))
        .pipe(buffer())
        .pipe(uglify())
        .pipe(gulp.dest('./dist'));
});

gulp.task('build-js', function() {
    return browserify('./lib/Flowing.js')
        .bundle()
        .pipe(source('Flowing.js'))
        .pipe(gulp.dest('./dist'));
});

gulp.task('default', ['build-js', 'build-min-js']);