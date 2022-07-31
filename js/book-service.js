export class BookService {
    
    displayBooks(dataService, books) {
        let bookListElement = document.querySelector('#bookList');
        books.forEach(book => {
            let bookElement = this.createBookElement(dataService, book);
            bookListElement.appendChild(bookElement);
        });
    }

    createBookElement(dataService, book) {
        let bookElement = document.createElement('p');
        bookElement.textContent = book.Title;
        bookElement.addEventListener("click", () => {
            let commonWords = dataService.getCommonWords(book.Id);
            this.displayCommonWords(book.Title, commonWords);
        });
        return bookElement;
    }

    displayCommonWords(title, commonWords) {
        let commonWordsElement = document.querySelector('#commonWordsList');
        commonWordsElement.textContent = '';
        commonWords.forEach(commonWord => {
            let commonWordElement = this.createCommonWordElement(commonWord);
            commonWordsElement.appendChild(commonWordElement);
        });

        let commonWordsTitle = document.querySelector('#commonWordsTitle');
        commonWordsTitle.textContent = "Most common words in \"" + title + "\"";
    }

    createCommonWordElement(commonWord) {
        let commonWordElement = document.createElement('p');
        commonWordElement.textContent = commonWord.Word + ' ' + commonWord.Count;
        return commonWordElement;
    }
}

