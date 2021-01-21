using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
namespace Library.DAL
{
	/// <summary>
	/// 数据访问类:book
	/// </summary>
	public partial class Book
	{
		public Book()
		{ }
		#region  BasicMethod


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Library.Model.Book model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into book(");
			strSql.Append("name,author,publish,price,date,isbn,cover)");
			strSql.Append(" values (");
			strSql.Append("@name,@author,@publish,@price,@date,@isbn,@cover)");
			strSql.Append(";select LAST_INSERT_ROWID()");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@name", DbType.String),
					new SQLiteParameter("@author", DbType.String),
					new SQLiteParameter("@publish", DbType.String),
					new SQLiteParameter("@price", DbType.Int32,8),
					new SQLiteParameter("@date", DbType.String),
					new SQLiteParameter("@isbn", DbType.String),
					new SQLiteParameter("@cover", DbType.String)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.author;
			parameters[2].Value = model.publish;
			parameters[3].Value = model.price;
			parameters[4].Value = model.date;
			parameters[5].Value = model.isbn;
			parameters[6].Value = model.cover;

			object obj = SQLiteHelper.GetSingle(strSql.ToString(), parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Library.Model.Book model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update book set ");
			strSql.Append("name=@name,");
			strSql.Append("author=@author,");
			strSql.Append("publish=@publish,");
			strSql.Append("price=@price,");
			strSql.Append("date=@date,");
			strSql.Append("isbn=@isbn,");
			strSql.Append("cover=@cover");
			strSql.Append(" where id=@id");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@name", DbType.String),
					new SQLiteParameter("@author", DbType.String),
					new SQLiteParameter("@publish", DbType.String),
					new SQLiteParameter("@price", DbType.Int32,8),
					new SQLiteParameter("@date", DbType.String),
					new SQLiteParameter("@isbn", DbType.String),
					new SQLiteParameter("@cover", DbType.String),
					new SQLiteParameter("@id", DbType.Int32,8)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.author;
			parameters[2].Value = model.publish;
			parameters[3].Value = model.price;
			parameters[4].Value = model.date;
			parameters[5].Value = model.isbn;
			parameters[6].Value = model.cover;
			parameters[7].Value = model.id;

			int rows = SQLiteHelper.ExecuteSql(strSql.ToString(), parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from book ");
			strSql.Append(" where id=@id");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@id", DbType.Int32,4)
			};
			parameters[0].Value = id;

			int rows = SQLiteHelper.ExecuteSql(strSql.ToString(), parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from book ");
			strSql.Append(" where id in (" + idlist + ")  ");
			int rows = SQLiteHelper.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Library.Model.Book GetModel(int id)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select id,name,author,publish,price,date,isbn,cover from book ");
			strSql.Append(" where id=@id");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@id", DbType.Int32,4)
			};
			parameters[0].Value = id;

			Library.Model.Book model = new Library.Model.Book();
			DataSet ds = SQLiteHelper.Query(strSql.ToString(), parameters);
			if (ds.Tables[0].Rows.Count > 0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Library.Model.Book DataRowToModel(DataRow row)
		{
			Library.Model.Book model = new Library.Model.Book();
			if (row != null)
			{
				if (row["id"] != null && row["id"].ToString() != "")
				{
					model.id = int.Parse(row["id"].ToString());
				}
				if (row["name"] != null)
				{
					model.name = row["name"].ToString();
				}
				if (row["author"] != null)
				{
					model.author = row["author"].ToString();
				}
				if (row["publish"] != null)
				{
					model.publish = row["publish"].ToString();
				}
				if (row["price"] != null && row["price"].ToString() != "")
				{
					model.price = int.Parse(row["price"].ToString());
				}
				if (row["date"] != null)
				{
					model.date = row["date"].ToString();
				}
				if (row["isbn"] != null)
				{
					model.isbn = row["isbn"].ToString();
				}
				if (row["cover"] != null)
				{
					model.cover = row["cover"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select id,name,author,publish,price,date,isbn,cover ");
			strSql.Append(" FROM book ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			return SQLiteHelper.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) FROM book ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			object obj = SQLiteHelper.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby);
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from book T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return SQLiteHelper.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@tblName", DbType.VarChar, 255),
					new SQLiteParameter("@fldName", DbType.VarChar, 255),
					new SQLiteParameter("@PageSize", DbType.Int32),
					new SQLiteParameter("@PageIndex", DbType.Int32),
					new SQLiteParameter("@IsReCount", DbType.bit),
					new SQLiteParameter("@OrderType", DbType.bit),
					new SQLiteParameter("@strWhere", DbType.VarChar,1000),
					};
			parameters[0].Value = "book";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return SQLiteHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

