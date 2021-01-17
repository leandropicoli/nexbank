(function () {
    'use strict';

    angular
        .module('app')
        .factory('AccountRepository', AccountRepository);

    AccountRepository.$inject = ['$http'];

    function AccountRepository($http) {
        var url = "https://localhost:5001/v1/account/"

        return {
            getAllAccounts: function () {
                return $http.get(url + 'getAll')
            },
            createAccount: function (account) {
                return $http.post(url, account)
            },
            getById: function (accountId) {
                return $http.get(url + 'getById?id=' + accountId)
            }
        }
    }
})();