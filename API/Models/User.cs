using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
	public class User
	{
		public int id { get; set; }
		public string userName{ get; set; }
		public string passWord{ get; set; }
		public string error { get; set; }
		public User(int id, string userName, string passWord, string error)
		{
			this.id = id;
			this.userName = userName;
			this.passWord = passWord;
			this.error = error;
		}
	}
}