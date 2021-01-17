(function () {
    'use strict';

    angular
        .module('app')
        .controller('HomeController', HomeController);

    HomeController.$inject = ['$scope', '$location', 'AccountRepository', '$rootScope'];

    function HomeController($scope, $location, AccountRepository, $rootScope) {
        $scope.name = '';
        $scope.lastName = '';
        $scope.document = '';

        $scope.createUser = function () {
            var fullName = $scope.name + ' ' + $scope.lastName;
            var account = {
                name: fullName,
                document: $scope.document
            }

            var promisse = AccountRepository.createAccount(account);

            promisse.then(
                function (result) {
                    $rootScope = result.data.data
                    toastr["success"]("Conta cadastrada com sucesso.", "Sucesso")
                }, function (error) {
                    console.log(error);
                }
            )
        }
    }
})();