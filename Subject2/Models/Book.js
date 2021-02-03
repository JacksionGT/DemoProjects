import axios from 'axios';
import config from '../Config'

class BookModel {
    getBookList(){
        return axios.get(`${config.apiHost}/GetBookList`)
    }
}

export default BookModel;
