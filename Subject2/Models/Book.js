import axios from 'axios';
import config from '../Config';
import DB from '../DB'
class BookModel {
    constructor(){
        this.db = new DB();
    }
    getBookList(){
        return this.db.getBooks();
    }
    getBookDetail(id){
        return this.db.getBookByid(id);
    }
    deleteBook(id){
        return this.db.deleteBook(id);
    }
    updateBook(book){
        return this.db.editBook(book);
    }
    addBook(book){
        return this.db.addBook(book);
    }
}

export default BookModel;
