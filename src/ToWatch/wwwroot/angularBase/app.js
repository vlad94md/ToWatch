(() => {
    let app = angular.module("main", ["ngRoute"]);

    app.config(['$routeProvider', '$locationProvider', function AppConfig($routeProvider, $locationProvider) {

        $routeProvider
        .when("/toprated", {
            templateUrl: "/angularBase/views/topRatedView.html",
            controller: "topRatedCtrl"
        })
        .when("/", {
            templateUrl: "/angularBase/views/upcomingView.html",
            controller: "upcommingCtrl"
        });

        // enable html5Mode for pushstate ('#'-less URLs)
        $locationProvider.html5Mode(true);
        $locationProvider.hashPrefix('!');

    }]);
})();