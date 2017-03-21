(() => {
    const app = angular.module("main");

    app.controller("topRatedCtrl", topRatedCtrl);

    function topRatedCtrl($scope, $http) {
        $http.get("/api/movies/toprated").then((response) => {
            $scope.topRatedMovies = response.data.results;
        });
    }
})();