
import Router from '@koa/router';
import HomeController from './HomeController';

const router = new Router();
const homeController = new HomeController();

function registerController(app){
    router.get('/',homeController.Index);
    router.get('/Home',homeController.List);
    router.get('/Home/List',homeController.List);
    router.get('/Home/About',homeController.About);
    router.get('/Home/AddBook',homeController.AddBook);
    router.get('/Home/DeleteBook/:id',homeController.DeleteBook);
    router.get('/Home/EditBook/:id',homeController.EditBook);
    router.post('/Home/BookOperation',homeController.OperationResult);
    
    app.use(router.routes()).use(router.allowedMethods());
}

export default registerController;
