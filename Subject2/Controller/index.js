
import Router from '@koa/router';
import HomeController from './HomeController';

const router = new Router();
const homeController = new HomeController();

function registerController(app){
    router.get('/',homeController.List);
    app.use(router.routes()).use(router.allowedMethods());
}

export default registerController;
