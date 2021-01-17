(function () {
    'use strict';

    angular
        .module('app')
        .controller('AccountController', AccountController);

    AccountController.$inject = ['$scope', '$location', 'AccountRepository', '$rootScope', '$window'];

    function AccountController($scope, $location, AccountRepository, $rootScope, $window) {
        $scope.account = null;
        if ($rootScope.account != null) {
            $window.localStorage.setItem('accountId', $rootScope.account.id)
            account = $rootScope.account;
        } else if ($window.localStorage.getItem('accountId') != null) {
            var accountId = $window.localStorage.getItem('accountId');

            var promisse = AccountRepository.getById(accountId);

            promisse.then(
                function (result) {
                    $scope.account = result.data;
                }, function (error) {
                    $location.path('/');
                }
            )
        } else {
            $location.path('/');
        }
    }
})();