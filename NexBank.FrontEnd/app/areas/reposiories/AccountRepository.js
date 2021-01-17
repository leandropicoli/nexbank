(function () {
    'use strict';

    angular
        .module('app')
        .factory('AccountRepository', AccountRepository);

    AccountRepository.$inject = ['$http'];

    function AccountRepository($http) {
        var url = "https://localhost:5001/v1/account"

        return {
            getAllAccounts: function () {
                console.log('vai buscar as contas');
            },
            createAccount: function (account) {
                return $http.post(url, account)
            }
        }
    }
})();