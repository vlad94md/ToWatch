(() => {
    var app = angular.module("main", ["ngRoute"]);

    app.config(($routeProvider) => {
        $routeProvider
            .when("/", {
                controller: "upcommingMovie",
                templateUrl: "/angularBase/views/upcommingMovie.html"
            }
            ).when("/toprated", {
                controller: "topRatedMovie",
                templateUrl: "/angularBase/views/topRatedMovie.html"
            });
    });
})();