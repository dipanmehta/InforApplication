app.controller('BookController', function($scope, $http, BookService) {

    LoadAllFiles();
    LoadAllFileFormats();

    function LoadAllFiles() {

        BookService.getAllFiles().then(function(response) {
            if (response != null) {
                var data = response.data;
                $scope.Files = data;
            }
        });
    }

    function LoadAllFileFormats() {
        BookService.getAllFileFormats().then(function (response) {
            if (response != null) {
                var data = response.data;
                $scope.FileFormats = data;
            }
        });
    }

    $scope.ImportAllFiles = function () {
      
        BookService.importAllFiles().then(function (response) {
            if (response != null) {
                var data = response.data;
                $scope.Books = data;
            }
        });
    }
});