using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
	public class Question
	{
		public int id { get; set; }
		public string statement { get; set; }
		public string alt_a { get; set; }
		public string alt_b { get; set; }
		public string alt_c { get; set; }
		public string alt_d { get; set; }
		public string alt_e { get; set; }
		public string answer { get; set; }
		public string identifier { get; set; }
		public string category { get; set; }
		public string second_statement { get; set; }
		public string url { get; set; }

		public Question(int id, string statement, string alt_a,
						string alt_b, string alt_c, string alt_d,
						string alt_e, string answer, string identifier,
						string category, string second_statement,
						string url)
		{
			this.id = id;
			this.statement = statement;
			this.alt_a = alt_a;
			this.alt_b = alt_b;
			this.alt_c = alt_c;
			this.alt_d = alt_d;
			this.alt_e = alt_e;
			this.answer = answer;
			this.identifier = identifier;
			this.category = category;
			this.second_statement = second_statement;
			this.url = url;
		}
	}
}