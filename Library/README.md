# 小书馆项目

一个基于ASP.NET的CRUD Demo

使用的技术
简单三层架构Model，DAL、BLL + APS.NET MVC 5 做WEB数据呈现
因为是Demo且数据量不大，使用了SQLite数据库
开发语言：C#

## Razor语法 Action link
@Html.ActionLink("编辑", "EditBook", new { id = book.id }, null)

http://localhost:4894/Home/EditBook/1



@Html.ActionLink("编辑", "EditBook", new { id = book.id, bookid = book.id }, null)

http://localhost:4894/Home/EditBook/1?bookid=1