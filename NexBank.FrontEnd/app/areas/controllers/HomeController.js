(function () {
    'use strict';

    angular
        .module('app')
        .controller('HomeController', HomeController);

    HomeController.$inject = ['$scope', '$location', 'AccountRepository'];

    function HomeController($scope, $location, AccountRepository) {

    }
})();