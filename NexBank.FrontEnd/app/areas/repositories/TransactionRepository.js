(function () {
    'use strict';

    angular
        .module('app')
        .factory('TransactionRepository', TransactionRepository);

    TransactionRepository.$inject = ['$http'];

    function TransactionRepository($http) {
        var url = "https://localhost:5001/v1/transaction/"

        return {
            getTransactions: function (dateFrom, dateTo, transactionType, accountId) {
                return $http({
                    url: url + 'getTransactions',
                    method: "GET",
                    params: {
                        dateFrom: dateFrom,
                        dateTo: dateTo,
                        transactionType: transactionType,
                        accountId: accountId
                    }
                });
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