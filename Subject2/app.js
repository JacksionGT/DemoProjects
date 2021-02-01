const Koa = require('koa');
const config = require('./Config')
const app = new Koa();
 
// response
app.use(ctx => {
  ctx.body = 'Hello Koa';
});
 
app.listen(config.port, () => {
  console.log(`kao2 应用启动在 http://localhost:${config.port}`);
});