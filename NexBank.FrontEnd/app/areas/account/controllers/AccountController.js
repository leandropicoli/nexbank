(function () {
    'use strict';

    angular
        .module('app')
        .controller('AccountController', AccountController);

    AccountController.$inject = ['$scope', '$location', 'AccountRepository', '$rootScope', '$window', 'TransactionRepository'];

    function AccountController($scope, $location, AccountRepository, $rootScope, $window, TransactionRepository) {
        $scope.account = null;
        if ($rootScope.account != null) {
            $window.localStorage.setItem('accountId', $rootScope.account.id)
            $scope.account = $rootScope.account;
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

        $scope.showExtractCard = false;

        $scope.filterDateFrom = '';
        $scope.filterDateTo = '';
        $scope.transactionType = '';

        $scope.transactions = null;
        $scope.showTransactions = false;

        $scope.enableExtract = function () {
            $scope.showExtractCard = true;
        }

        $scope.getTransactions = function () {
            var promisse = TransactionRepository.getTransactions(
                $scope.filterDateFrom,
                $scope.filterDateTo,
                $scope.transactionType,
                $scope.account.id)

            promisse.then(
                function (result) {
                    console.log(result)
                    $scope.transactions = result.data;
                    $scope.showTransactions = true;
                },
                function (error) {
                    console.log(error)
                }
            )
        }
    }
})();