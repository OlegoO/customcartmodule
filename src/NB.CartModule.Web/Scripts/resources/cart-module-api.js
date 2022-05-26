angular.module('CartModuleModule')
    .factory('CartModuleModule.webApi', ['$resource', function ($resource) {
        return $resource('api/CartModuleModule');
}]);
