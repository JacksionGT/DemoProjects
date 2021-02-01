using System;
namespace Library.Model
{
	/// <summary>
	/// book:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Book
	{
		public Book()
		{ }
		#region Model
		private int? _id = 0;
		private string _name;
		private string _author;
		private string _publish;
		private decimal? _price;
		private string _date;
		private string _isbn;
		private string _cover;
		/// <summary>
		/// 图书id
		/// </summary>
		public int? id
		{
			set { _id = value; }
			get { return _id; }
		}
		/// <summary>
		/// 书名
		/// </summary>
		public string name
		{
			set { _name = value; }
			get { return _name; }
		}
		/// <summary>
		/// 作者
		/// </summary>
		public string author
		{
			set { _author = value; }
			get { return _author; }
		}
		/// <summary>
		/// 出版社
		/// </summary>
		public string publish
		{
			set { _publish = value; }
			get { return _publish; }
		}
		/// <summary>
		/// 价格
		/// </summary>
		public decimal? price
		{
			set { _price = value; }
			get { return _price; }
		}
		/// <summary>
		/// 录入日期
		/// </summary>
		public string date
		{
			set { _date = value; }
			get { return _date; }
		}
		/// <summary>
		/// 书ISBN
		/// </summary>
		public string isbn
		{
			set { _isbn = value; }
			get { return _isbn; }
		}
		/// <summary>
		/// 封面
		/// </summary>
		public string cover
		{
			set { _cover = value; }
			get { return _cover; }
		}
		#endregion Model

	}
}

