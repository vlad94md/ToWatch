﻿(() => {
    const app = angular.module("main");

    app.controller("topRatedCtrl", topRatedCtrl);

    function topRatedCtrl($scope, $http) {
        $scope.isLoaded = false;

        $http.get("/api/movies/toprated").then((response) => {
            $scope.movies = response.data.results;
        }).finally(()=>{
            $scope.isLoaded = true;
        });
    }
})();