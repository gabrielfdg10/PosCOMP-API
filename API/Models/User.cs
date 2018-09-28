using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
	public class User
	{
		public int id { get; set; }
		public string member_since { get; set; }
		public string email { get; set; }
		public string real_name { get; set; }
		public string institution { get; set; }
		public string username { get; set; }
		public string password { get; set; }
		public User(int id, string member_since, string userName, string email, 
					string passWord, string real_name, string institution)
		{
			this.id = id;
			this.member_since = member_since;
			this.username = userName;
			this.email = email;
			this.password = passWord;
			this.real_name = real_name;
			this.institution = institution;
		}
	}
}