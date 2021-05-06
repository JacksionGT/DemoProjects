import Controller from './Controller';
import BookModel from '../Models/Book';

const booksModel = new BookModel();

class HomeController extends Controller {
    constructor() {
        super()
    }
    async Index(ctx) {
        ctx.body = await ctx.render('Home/Index');
    }
    async List(ctx) {
        const data = await booksModel.getBookList();
        ctx.body = await ctx.render('Home/List', { data: data });
    }
    async AddBook(ctx) {
        ctx.body = await ctx.render('Home/AddBook');
    }
    async EditBook(ctx) {
        // console.log(ctx.params);
        const { id } = ctx.params;
        const data = await booksModel.getBookDetail(id);
        console.log(data);
        ctx.body = await ctx.render('Home/EditBook', { book: data });
    }
    async DeleteBook(ctx) {
        const { id } = ctx.params;
        const data = await booksModel.getBookDetail(id);
        const html = await ctx.render('Home/delbook', { book: data });
        ctx.body = html;
    }
    async OperationResult(ctx) {
        const { type, ...rest } = ctx.request.body;
        console.log(type, rest);
        let res = false;
        if (type === 'add') {
            res = await booksModel.addBook(rest);
        }
        if (type === 'edit') {
            res = await booksModel.updateBook(rest)
        }
        if (type === 'delete') {
            res = await booksModel.deleteBook(rest.id);
        }
        if (res === true) {
            ctx.body = await ctx.render('Home/OperationResult', { message: '操作成功' });
        } else {
            ctx.body = await ctx.render('Home/OperationResult', { message: `操作失败,${JSON.stringify(res)}` });
        }
    }
    async About(ctx) {
        ctx.body = await ctx.render('Home/About');
    }
}

export default HomeController;
