(() => {
    var app = angular.module("main");
    app.controller("upcommingMovie", upcommingMovie);

    function upcommingMovie($scope, $http) {

        $http.get("api/movies/upcomming")
            .then((response) => {
                $scope.upcommingMovies = response.data.results;
            });

    }
})();