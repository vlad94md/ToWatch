(() => {
    let app = angular.module("main", ["ngRoute"]);

    app.config(($routeProvider) => {
        $routeProvider
        .when("/", {
            templateUrl: "/angularBase/views/upcomingView.html",
            controller: "upcommingCtrl"
        })
        .when("/toprated", {
            templateUrl: "/angularBase/views/topRatedView.html",
            controller: "topRatedCtrl"
        });
    });
})();