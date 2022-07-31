export class DataService {
    getRequest(url) {
        let xmlHttpReq = new XMLHttpRequest();
        xmlHttpReq.open("GET", url, false);
        xmlHttpReq.send(null);
        let response = JSON.parse(xmlHttpReq.response);
        return response;
    }

    getBooks() {
        let books = this.getRequest("http://localhost:49265/api/books");
        return books;
    }

    getCommonWords(id) {
        let commonWords = this.getRequest(`http://localhost:49265/api/books/${id}`);
        return commonWords;
    }
}

