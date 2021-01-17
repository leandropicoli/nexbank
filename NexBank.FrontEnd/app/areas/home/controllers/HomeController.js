(function () {
    'use strict';

    angular
        .module('app')
        .controller('HomeController', HomeController);

    HomeController.$inject = ['$scope', '$location', 'AccountRepository', '$rootScope', '$window'];

    function HomeController($scope, $location, AccountRepository, $rootScope, $window) {
        $scope.name = '';
        $scope.lastName = '';
        $scope.document = '';
        $rootScope.account = null;

        $scope.createUser = function () {
            var fullName = $scope.name + ' ' + $scope.lastName;
            var account = {
                name: fullName,
                document: $scope.document
            }

            var promisse = AccountRepository.createAccount(account);

            promisse.then(
                function (result) {
                    $rootScope.account = result.data.data
                    toastr["success"]("Conta cadastrada com sucesso.", "Sucesso")
                    $location.path('/account')
                }, function (error) {
                    console.log(error);
                }
            )
        }

        $scope.goToAccounts = function () {
            $location.path('/accounts-list');
        }
    }
})();