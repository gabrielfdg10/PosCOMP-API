using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
	public class Stats
	{
		public int id { get; set; }
		public int math_ans { get; set; }
		public int tech_ans { get; set; }
		public int fund_ans { get; set; }
		public int math_cor { get; set; }
		public int tech_cor { get; set; }
		public int fund_cor { get; set; }
		public int test_made { get; set; }
		public int random_test { get; set; }
		public int custom_test { get; set; }

		public Stats(int id, int math_ans, int tech_ans, int fund_ans,
					int math_cor, int tech_cor, int fund_cor, int test_made,
					int random_test, int custom_test)
		{
			this.id = id;
			this.math_ans = math_ans;
			this.tech_ans = tech_ans;
			this.fund_ans = fund_ans;
			this.math_cor = math_cor;
			this.tech_cor = tech_cor;
			this.fund_cor = fund_cor;
			this.test_made = test_made;
			this.random_test = random_test;
			this.custom_test = custom_test;
		}
	}
}
