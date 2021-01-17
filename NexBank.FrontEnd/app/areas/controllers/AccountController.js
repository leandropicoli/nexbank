(function () {
    'use strict';

    angular
        .module('app')
        .controller('AccountController', AccountController);

    AccountController.$inject = ['$scope', '$location', 'AccountRepository', '$rootScope'];

    function AccountController($scope, $location, AccountRepository, $rootScope) {

    }
})();