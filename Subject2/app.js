import Koa from 'koa';
import koaBody from 'koa-body';
import render from 'koa-swig';
import path from 'path';
import co from 'co';
import serve from 'koa-static';

import config from './Config';
import registerController from './Controller';

const app = new Koa();
app.use(koaBody());
app.use(serve(__dirname + '/assets'));

registerController(app);

app.context.render = co.wrap(render({
  root: path.join(__dirname, 'Views'),
  ext: 'html',
}));

app.listen(config.port, () => {
  console.log(`kao2 应用启动在 http://localhost:${config.port}`);
});