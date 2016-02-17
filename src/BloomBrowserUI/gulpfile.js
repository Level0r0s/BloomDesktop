/// <binding BeforeBuild='default' ProjectOpened='default' />
var gulp = require('gulp');  
var debug = require('gulp-debug');
var ts = require('gulp-typescript');
var less = require('gulp-less');
var jade = require('gulp-jade');
var path = require('path');
var sourcemaps = require('gulp-sourcemaps');

var paths = {
   typescript: ['./**/*.ts','!./**/*.d.ts','!./node_modules/**/*.*'],
   less: ['./**/*.less',  '!./node_modules/**/*.less'],
  jade: ['./**/*.jade',  '!./node_modules/**/*.jade']
};
//Currently we are putting all css's into the same directories as the less
//A next step would be to set it out to \output but that will require 
//changing where things are looked for at development time and on user machines,
//and some build/installer modifications
gulp.task('less', function () {
  return gulp.src(paths.less)
    .pipe(debug({title: 'less:'}))
    .pipe(sourcemaps.init())
    .pipe(less())
    .pipe(sourcemaps.write('./'))
    .pipe(gulp.dest('./')); //drop all css's into the same dirs.
});

gulp.task('jade', function () {
  return gulp.src(paths.jade)
    .pipe(debug({title: 'jade:'}))
    .pipe(jade())
    .pipe(gulp.dest('./')); //drop all css's into the same dirs.
});

gulp.task('typescript', function () {
  return gulp.src(paths.typescript)
    .pipe(debug({title: 'typescript:'}))
    .pipe(sourcemaps.init())
    .pipe(ts())
    .pipe(sourcemaps.write('./'))
    .pipe(gulp.dest('./')); //drop all js's into the same dirs.
});

// Rerun the task when a file changes
gulp.task('watch', function() {
  gulp.watch(paths.typescript, ['typescript']),
  gulp.watch(paths.less, ['less']),
  gulp.watch(paths.jade, ['jade']);
});

gulp.task('default', ['typescript', 'less', 'jade']);