app.service('BookService',function($http, $q) {

    this.getAllFiles = function() {
        
        var request = $http({
            method: "get",
            url: "/api/Book/AllFiles"
        });
        return request;
    }

    this.getAllFileFormats = function() {
        var request = $http({
            method: "get",
            url: "/api/Book/AllFileFormats"
        });
        return request;
    }

    this.importAllFiles = function() {
        
        var request = $http({
            method: "get",
            url: "/api/Book/ImportAllFiles"
        });
        return request;
    }

});