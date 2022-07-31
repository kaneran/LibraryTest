import { BookService } from "./book-service.js";
import { DataService } from "./data-service.js";

class App
{
    _dataService;
    _bookService;
	constructor() {
        this._dataService = new DataService();
        this._bookService = new BookService();
    }

    

    go() {
        // retrieve and display the list of books
        let books = this._dataService.getBooks();
        this._bookService.displayBooks(this._dataService, books);
	}
}
new App().go();