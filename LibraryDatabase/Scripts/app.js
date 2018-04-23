angular.
    module("libraryApp", [])
    .controller("mainController", ["$scope", "$http", ($scope, $http) => {

        $scope.currentTime = new Date();

        $http({
            method: "GET",
            url: "/api/books"
        }).then(resp => {
            console.log(resp.data);
            $scope.books = resp.data;
        })
    }]);

//PUT WILL LOOK LIKE:
//$http({
//method: "PUT",//what I am doing
  //  url: "/api/book"//where am I doing it
    //data: JSON.stringify(email: "email from UI text box goes here.")


      //  }).then(resp => {
    //console.log(resp.data);
    //$scope.books = resp.data;