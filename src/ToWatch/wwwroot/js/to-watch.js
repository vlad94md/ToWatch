(function () {

    angular.module("to-watch", ["customControls", "ngRoute"])
    .config(function ($routeProvider) {

        $routeProvider.when("/", {
            controller: "moviesController",
            controllerAs: "vm",
            templateUrl: "/views/moviesView.html"
        });

        $routeProvider.when("/search/:movieName", {
            controller: "searchMovieController",
            controllerAs: "vm",
            templateUrl: "/views/searchMovieView.html"
        });

        $routeProvider.otherwise({ redirectTo: "/" });
    });

})();