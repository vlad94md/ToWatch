(() => {
    var app = angular.module("main");
    app.controller("topRatedMovie", topRatedMovie);

    function topRatedMovie($scope, $http) {

        $scope.path = "/topratwdwded"

        $http.get("api/movies/toprated")
            .then((response) => {
                $scope.topRatedMovies = response.data.results;
            });

    }
})();