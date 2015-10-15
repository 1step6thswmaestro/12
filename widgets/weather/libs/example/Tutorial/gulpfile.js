var gulp = require('gulp');
var less = require('gulp-less');
var minifyCss = require('gulp-minify-css');
var uglify = require('gulp-uglify');
var buffer = require('vinyl-buffer');

var browserify = require('browserify');
var source = require('vinyl-source-stream');

var nodemon = require('gulp-nodemon');
var browserSync = require('browser-sync').create();

var paths = {
    js: ['./src/**/**/*.js', './src/**/*.js', './src/*.js'],
    views: './src/index.html',
    styles: './src/main.less'
};


gulp.task('build-js', function() {
    return browserify('./src/main.js')
        .bundle()
        .pipe(source('main.js'))
        .pipe(buffer())
        .pipe(uglify())
        .pipe(gulp.dest('./build/js'))
        .pipe(browserSync.stream());
});


gulp.task('build-views', function() {
    return gulp.src(paths.views)
        .pipe(gulp.dest('./build'))
        .pipe(browserSync.stream());
});

gulp.task('build-styles', function() {
    return gulp.src(paths.styles)
        .pipe(less())
        .pipe(minifyCss())
        .pipe(gulp.dest('./build/css'))
        .pipe(browserSync.stream());
});


gulp.task('run', ['build-js', 'build-views', 'build-styles'], function(cb) {
    var called = false;
    browserSync.init({
        proxy: 'http://localhost:8888',
        port: 3000,
        open: false
    });

    nodemon({
        script: 'app.js',
        env: {
            'NODE_ENV': 'development'
        },
        watch: ['app.js']
    })
        .on('start', function onStart() {
            if (!called) {
                cb();
                called = true;
            }
        })
        .on('restart', function onRestart() {
            setTimeout(function reload() {
                browserSync.reload({
                    stream: false
                });
            }, 500);
        });

    gulp.watch(paths.js, ['build-js']);
    gulp.watch(paths.views, ['build-views']);
    gulp.watch(paths.styles, ['build-styles']);

});


gulp.task('default', ['run']);