(function () {
    "use strict";

    angular.module("customControls", []).directive("loading", loadingAnimation);

    function loadingAnimation() {
        return {
            scope: {
                show: "=displayWhen"
            },
            restrict: "E",
            templateUrl: "/views/loadingMovies.html"
        };
    };
})();