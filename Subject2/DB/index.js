
import { resolve } from 'path';

import sqlite3 from 'sqlite3';

const sqlite = sqlite3.verbose();

class DB {
    constructor() {
        const sqlite = sqlite3.verbose();
        this.db = new sqlite.Database(resolve(__dirname, './Book.db'));
        console.log(this.db);
    }
    getBooks() {
        return new Promise((resolve, reject) => {
            this.db.all('select id,name,author,publish,price,date,isbn,cover from book', function (err, row) {
                if (!err) {
                    resolve(row)
                } else {
                    reject(err)
                }
            })
        })
    }
    getBookByid(id) {
        return new Promise((resolve, reject) => {
            this.db.get('select id,name,author,publish,price,date,isbn,cover from book where id = ?', id, function (err, row) {
                if (!err) {
                    resolve(row)
                } else {
                    reject(err)
                }
            })
        })
    }
    addBook(data) {
        const sql = 'insert into book(name,author,publish,price,date,isbn,cover) values (? ,? ,? ,? ,? ,? ,?)';
        var stmt = this.db.prepare(sql);
        return new Promise((resolve, reject) => {
            stmt.run(data.name, data.author, data.publish, data.price, new Date(), data.isbn, data.cover, function (err) {
                if (!err) {
                    resolve(true)
                } else {
                    reject(err)
                }
            })
        })
    }
    editBook(data) {
        const sql = 'update book set name=?,author=?,publish=?,price=?,isbn=?,cover=? where id=?';
        return new Promise((resolve, reject) => {
            this.db.run(sql, data.name, data.author, data.publish, data.price, data.isbn, data.cover, data.id, function (err) {
                if (!err) {
                    resolve(true)
                } else {
                    reject(err)
                }
            });
        })
    }
    deleteBook(id) {
        const sql = 'delete from book where id = ?';
        return new Promise((resolve, reject) => {
            this.db.exec(sql, id, function (err) {
                if (!err) {
                    resolve(true)
                } else {
                    reject(err)
                }
            });
        })
    }
}

export default DB