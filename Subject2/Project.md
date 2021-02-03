### To do list
* vscode babel-node 调试
* 完善剩余功能
* nodemon监听刷新 view/ model/ config等
* 进一步学习swig模板引擎[swig](https://www.jianshu.com/p/f0bffc42c1ce)

示例 nodemon.json
``` json
{
     "restartable": "rs",
     "ignore": [
         ".git",
         "node_modules/**/node_modules"
     ],
     "verbose": true,
     "execMap": {
         "": "node",
         "js": "node --harmony"
     },
     "events": {
         "restart": "osascript -e 'display notification \"App restarted due to:\n'$FILENAME'\" with title \"nodemon\"'"
     },
     "watch": [
         "test/fixtures/",
         "test/samples/"
     ],
     "env": {
         "NODE_ENV": "development",
         "PORT": "3000"
     },
     "ext": "js json",
     "legacy-watch": false
 }
```

