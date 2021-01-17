(function () {
    'use strict';

    var app = angular.module('app', ['ngRoute', 'ngAnimate', '720kb.datepicker']);

    app.config(function ($routeProvider) {
        $routeProvider
            .when('/', {
                controller: 'HomeController',
                templateUrl: 'app/areas/home/views/index.html'
            })
            .when('/account', {
                controller: 'AccountController',
                templateUrl: 'app/areas/account/views/index.html'
            })
            .when('/accounts-list', {
                controller: 'AccountListController',
                templateUrl: 'app/areas/account/views/accounts-list.html'
            })
            .otherwise({
                controller: 'HomeCtrl as vm',
                templateUrl: '404.html',
                requiresLogin: false
            });
    });

    app.controller('AppCtrl', function AppCtrl($scope, $http) {

    });

})();