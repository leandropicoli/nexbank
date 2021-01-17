(function () {
    'use strict';

    angular
        .module('app')
        .factory('AccountRepository', AccountRepository);

    AccountRepository.$inject = ['$http'];

    function AccountRepository($http) {
        return {
            getAllAccounts: function () {
                console.log('vai buscar as contas');
            }
        }
    }
})();