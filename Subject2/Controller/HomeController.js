import Controller from './Controller';
import BookModel from '../Models/Book';

const booksModel = new BookModel();

class HomeController extends Controller {
    constructor() {
        super()
    }
    async List(ctx) {
        const data = await booksModel.getBookList();
        console.log(Object.keys(data.data));
        ctx.body = await ctx.render('Home/List', {data: data.data});
    }
}

export default HomeController;
