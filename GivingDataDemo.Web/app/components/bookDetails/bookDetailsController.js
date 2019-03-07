

app.controller('BookDetailsController', function($scope, $routeParams, BookService) {

    $scope.isBusy = true;
    $scope.book = {};
    $scope.bookReviews = {};
    $scope.newBookReview = {};

    $scope.addBookReview = addBookReview;
    $scope.setNewBookReviewRating = setNewBookReviewRating;

    construct();
    function construct() {

        // Load the book details async
        BookService.getBook($routeParams.bookId).then(function (response) {
            $scope.book = response.data;
            $scope.isBusy = false;
        });
        
        // Load the book reviews async
        BookService.getBookReviews($routeParams.bookId).then(function (response) {
            $scope.bookReviews = response.data;
        });
    }

    function setNewBookReviewRating(rating) {
        $scope.newBookReview.Rating = rating;
    }

    function addBookReview() {
        $scope.newBookReview.googleBookId = $routeParams.bookId;
        BookService.addBookReview($scope.newBookReview).then(function (response) {
            $scope.bookReviews.push(response.data);     // add the new review to the list
            $scope.newBookReview = {};                  // clear out the form
        });
    }
});

