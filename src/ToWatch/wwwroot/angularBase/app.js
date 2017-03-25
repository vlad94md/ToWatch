(() => {
    let app = angular.module("main", ["ngRoute"]);

    app.config(['$routeProvider', '$locationProvider', function AppConfig($routeProvider, $locationProvider) {

        $routeProvider
        .when("/toprated", {
            templateUrl: "/angularBase/views/moviesView.html",
            controller: "topRatedCtrl"
        })
        .when("/popular", {
            templateUrl: "/angularBase/views/moviesView.html",
            controller: "popularCtrl"
        })
        .when("/", {
            templateUrl: "/angularBase/views/moviesView.html",
            controller: "upcommingCtrl"
        });

        // enable html5Mode for pushstate ('#'-less URLs)
        $locationProvider.html5Mode(true);
        $locationProvider.hashPrefix('!');
    }]);
})();