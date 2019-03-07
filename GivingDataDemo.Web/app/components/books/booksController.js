
app.controller('BooksController', function($scope, $location, BookService) {
    $scope.isLoading;
    $scope.books;
    $scope.numberOfResultsOptions;
    $scope.numberOfResults;
    $scope.keywords;

    $scope.viewBookDetails = viewBookDetails;
    $scope.getBooks = getBooks;

    construct();
    function construct() {
        $scope.books = [];                                                  // default to empty array
        $scope.numberOfResultsOptions = [5, 10, 20, 40];                    // list of select options
        $scope.numberOfResults = 40;                                        // set default
        $scope.keywords = "National Parks";                                 // set default

        getBooks();
    }
    
    function getBooks() {
        $scope.isLoading = true;

        // Get list of books from the BookService 
        BookService.getBooks($scope.keywords, $scope.numberOfResults)
            .then(function (response) {
                $scope.books = response.data;
                $scope.isLoading = false;
            });
    }

    function viewBookDetails(book) {
        $location.path('/bookdetails/' + book.Id);
    }
    
});