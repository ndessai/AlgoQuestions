'use strict';

var serveStatic = require('serve-static');

// # Globbing
// for performance reasons we're only matching one level down:
// 'test/spec/{,*/}*.js'
// use this if you want to recursively match all subfolders:
// 'test/spec/**/*.js'

module.exports = function (grunt) {
  var pkg = grunt.file.readJSON("package.json");

  // Project configuration.
  grunt.initConfig({
    // Metadata.
    pkg: pkg,
    // Task configuration.
    uglify: {
      dist: {
        src: "<%= concat.dist.dest %>",
        dest: "dist/<%= pkg.name %>-min.js"
      }
    },
    clean: {
      dist: ["dist"],
      server: '.tmp'
    },
    concat: {
      dist: {
        dest: "dist/<%= pkg.name %>.js",
        src: [
          "app/scripts/eldataservices.js",
          "app/scripts/**/!(eldataservices)*.js"
        ]
      }
    },
    jshint: {
      options: {
        jshintrc: '.jshintrc',
        reporter: require('jshint-stylish')
      },
      all: {
        src: [
          'Gruntfile.js',
          'app/scripts/{,*/}*.js'
        ]
      },
      test: {
        options: {
          jshintrc: 'test/.jshintrc'
        },
        src: ['test/spec/{,*/}*.js']
      }
    },
    karma: {
      unit: {
        configFile: 'test/karma.conf.js',
        singleRun: true
      }
    },
    ngtemplates: {
      elsharedcomponents: {
        cwd: 'app',
        src: 'views/**/*.html',
        dest: '.tmp/scripts/template.js'
      }
    },
    copy: {
      toportal: {
        files: [
          {
            expand: true,
            cwd: 'dist',
            src: ['eldataservices*.js'],
            dest: '../webapps.elportal/bower_components/eldataservices/dist'
          }
        ]
      },
      tolocalization: {
        files: [
          {
            expand: true,
            cwd: 'dist',
            src: ['eldataservices*.js'],
            dest: '../webapps.localizationservices/bower_components/eldataservices/dist'
          }
        ]
      },
      sharedcomponents: {
        files: [
          {
            expand: true,
            cwd: 'dist',
            src: ['eldataservices*.js'],
            dest: '../webapps.shared_components/bower_components/eldataservices/dist'
          }
        ]
      },
      toapplibrary: {
        files: [
          {
            expand: true,
            cwd: 'dist',
            src: ['eldataservices*.js'],
            dest: '../AppLibrary/src/scripts/libs/bower_components/eldataservices/dist'
          }
        ]
      }
    },
    wiredep: {
      app: {
        src: ['app/test/index.html'],
        ignorePath: /\.\.\//,
        options: {
          devDependencies: true,
          exclude: ['bower_components/angular-mock']
        }
      },
      test: {
        devDependencies: true,
        src: '<%= karma.unit.configFile %>',
        ignorePath: /\.\.\//,
        fileTypes: {
          js: {
            block: /(([\s\t]*)\/{2}\s*?bower:\s*?(\S*))(\n|\r|.)*?(\/{2}\s*endbower)/gi,
            detect: {
              js: /'(.*\.js)'/gi
            },
            replace: {
              js: '\'{{filePath}}\','
            }
          }
        }
      }
    },
    // Watches files for changes and runs tasks based on the changed files
    watch: {
      bower: {
        files: ['bower.json'],
        tasks: ['wiredep']
      },
      js: {
        files: ['app/scripts/**/*.js'],
        tasks: ['newer:jshint:all'],
        options: {
          livereload: '<%= connect.options.livereload %>'
        }
      },
      gruntfile: {
        files: ['Gruntfile.js']
      },
      livereload: {
        options: {
          livereload: '<%= connect.options.livereload %>'
        },
        files: [
          '**/*.html'
        ]
      }
    },
    connect: {
      options: {
        port: 9003,
        // Change this to '0.0.0.0' to access the server from outside.
        hostname: 'localhost',
        livereload: 39003
      },
      livereload: {
        options: {
          open: true,
          middleware: function (connect) {
            return [
              serveStatic('.tmp'),
              connect().use(
                '/bower_components',
                serveStatic('./bower_components')
              ),
              connect().use(
                '/fonts',
                serveStatic('./app/test/fonts')
              ),
              connect().use(
                '/images',
                serveStatic('./app/test/images')
              ),
              connect().use(
                '/scripts',
                serveStatic('./app/scripts')
              ),
              serveStatic('./app/test')
            ];
          }
        }
      }
    },

    // Update version in Javascript files
    version: {
      default: {
        options: {
          pkg: 'package.json',
          prefix: 'versionProvider.register\\s*[(]\\s*[\'"]eldataservices[\'"]\\s*,\\s*[\'"]'
        },
        src: ['app/scripts/eldataservices.js']
      }
    },

    // Bump, deploy
    bump: {
      options: {
        files: ['bower.json', 'package.json'],
        tagName: '%VERSION%',
        pushTo: 'origin',
        commitFiles: ['bower.json', 'package.json', 'app/scripts/eldataservices.js', 'dist/*.js']
      }
    },

    devUpdate: {
      report: {
        options: {
          updateTypeupdateType: 'report', //just report outdated packages
          reportUpdated: false, //don't report up-to-date packages
          semver: false, //stay within semver when updating
          packages: {
            devDependencies: true,
            dependencies: true
          },
          packageJson: null, //use matchdep default findup to locate package.json
          reportOnlyPkgs: [] //use updateType action on all packages
        }
      },
      update: {
        options: {
          updateType: 'prompt', //just report outdated packages
          reportUpdated: false, //don't report up-to-date packages
          semver: false, //stay within semver when updating
          packages: {
            devDependencies: true,
            dependencies: true
          },
          packageJson: null, //use matchdep default findup to locate package.json
          reportOnlyPkgs: [] //use updateType action on all packages
        }
      }
    }
  });

  // These plugins provide necessary tasks.
  grunt.loadNpmTasks("grunt-contrib-concat");
  grunt.loadNpmTasks("grunt-contrib-copy");
  grunt.loadNpmTasks("grunt-contrib-uglify");
  grunt.loadNpmTasks("grunt-contrib-jshint");
  grunt.loadNpmTasks("grunt-contrib-clean");
  grunt.loadNpmTasks("grunt-angular-templates");
  grunt.loadNpmTasks("grunt-contrib-connect");
  grunt.loadNpmTasks("grunt-contrib-watch");
  grunt.loadNpmTasks("grunt-contrib-copy");
  grunt.loadNpmTasks("grunt-newer");
  grunt.loadNpmTasks("grunt-wiredep");
  grunt.loadNpmTasks("grunt-karma");
  grunt.loadNpmTasks("grunt-version");
  grunt.loadNpmTasks("grunt-bump");
  grunt.loadNpmTasks("grunt-dev-update");

  // Default task.
  grunt.registerTask("default", ["clean", "jshint", "wiredep:test", "karma", "concat", "uglify"]);
  grunt.registerTask("portal", ["default", "copy:toportal"]);
  grunt.registerTask("localization", ["default", "copy:tolocalization"]);
  grunt.registerTask("applibrary", ["default", "copy:toapplibrary"]);
  grunt.registerTask("sharedcomponents", ["default", "copy:sharedcomponents"]);
  grunt.registerTask("serve", ["clean:server", "jshint", "wiredep:app", "connect:livereload", "watch"]);
  grunt.registerTask("release", ["version::patch", "default", "bump:patch"]);
  grunt.registerTask("release:minor", ["version::minor", "default", "bump:minor"]);
  grunt.registerTask("release:major", ["version::major", "default", "bump:major"]);
};
