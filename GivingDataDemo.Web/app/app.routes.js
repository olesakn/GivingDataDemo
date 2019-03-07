

app.config(function ($routeProvider, $locationProvider) {

    $routeProvider
        .when("/books", {
            controller: "BooksController",
            templateUrl: "/app/components/books/booksView.html"
        })
        .when("/bookdetails/:bookId", {
            controller: "BookDetailsController",
            templateUrl: "/app/components/bookDetails/bookDetailsView.html"
        })
        .otherwise('/books');

    // use the HTML5 History API
    $locationProvider.html5Mode(true);
});