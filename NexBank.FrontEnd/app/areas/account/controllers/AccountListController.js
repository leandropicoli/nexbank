(function () {
    'use strict';

    angular
        .module('app')
        .controller('AccountListController', AccountListController);

    AccountListController.$inject = ['$scope', '$location', 'AccountRepository', '$rootScope', '$window'];

    function AccountListController($scope, $location, AccountRepository, $rootScope, $window) {
        $scope.accounts = null;

        var promisse = AccountRepository.getAllAccounts();

        promisse.then(
            function (result) {
                $scope.accounts = result.data;
            },
            function (error) {
                console.log(error);
            }
        )

        $scope.goToAccount = function (account) {
            $rootScope.account = account;
            $window.localStorage.setItem('accountId', account.id)
            $location.path('/account')
        }
    }
})();