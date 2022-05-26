angular.module('CartModuleModule')
    .controller('CartModuleModule.helloWorldController', ['$scope', 'CartModuleModule.webApi', function ($scope, api) {
        var blade = $scope.blade;
        blade.title = 'CartModuleModule';

        blade.refresh = function () {
            api.get(function (data) {
                blade.title = 'CartModuleModule.blades.hello-world.title';
                blade.data = data.result;
                blade.isLoading = false;
            });
        };

        blade.refresh();
    }]);
