(() => {
    const app = angular.module("main");

    app.controller("searchCtrl", ["$scope", "$rootScope", "movieService", function searchCtrl($scope, $rootScope, movieService) {
        $scope.modelArr = '';

        $scope.testChange = (val) => {
            var movieContainer = document.getElementById("movie-container");
            movieContainer.innerHTML = renderDefault(val);
        }


        function renderDefault(val) {
            var filteredMovies = $rootScope.movies.filter((movie, index) => {
                return movie.title.toLowerCase().includes(val.toLowerCase());
            });
            
            const ul = document.createElement('ul');
            ul.id = 'movie-list';

            filteredMovies.forEach((movie) => {
                const li = document.createElement('li');
                const div = document.createElement('div');
                const img = document.createElement('img');
                img.className = 'img-responsive';
                img.src = movie.posterPath;
                div.appendChild(img);
                li.appendChild(div);
                ul.appendChild(li);
            })

            return ul.outerHTML;
        }

    }]);
})();