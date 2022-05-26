// Call this to register your module to main application
var moduleName = 'CartModuleModule';

if (AppDependencies !== undefined) {
    AppDependencies.push(moduleName);
}

angular.module(moduleName, [])
    .config(['$stateProvider', '$urlRouterProvider',
        function ($stateProvider, $urlRouterProvider) {
            $stateProvider
                .state('workspace.CartModuleModuleState', {
                    url: '/CartModuleModule',
                    templateUrl: '$(Platform)/Scripts/common/templates/home.tpl.html',
                    controller: [
                        '$scope', 'platformWebApp.bladeNavigationService', function ($scope, bladeNavigationService) {
                            var newBlade = {
                                id: 'blade1',
                                controller: 'CartModuleModule.helloWorldController',
                                template: 'Modules/$(NB.CartModule)/Scripts/blades/hello-world.html',
                                isClosingDisabled: true
                            };
                            bladeNavigationService.showBlade(newBlade);
                        }
                    ]
                });
        }
    ])
    .run(['platformWebApp.mainMenuService', 'platformWebApp.widgetService', '$state',
        function (mainMenuService, widgetService, $state) {
            //Register module in main menu
            var menuItem = {
                path: 'browse/CartModuleModule',
                icon: 'fa fa-cube',
                title: 'CartModuleModule',
                priority: 100,
                action: function () { $state.go('workspace.CartModuleModuleState'); },
                permission: 'CartModuleModule:access'
            };
            mainMenuService.addMenuItem(menuItem);
        }
    ]);
