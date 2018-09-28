using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
	public class Test
	{
		public int user_id { get; set; }
		public int id { get; set; }
		public string timestart { get; set; }
		public string timeend { get; set; }
		public int math_number_questions { get; set; }
		public int fund_number_questions { get; set; }
		public int tech_number_questions { get; set; }
		public int math_correct_answers { get; set; }
		public int fund_correct_answers { get; set; }
		public int tech_correct_answers { get; set; }
		public double accuracy { get; set; }

		public Test(int id, int user_id, 
					string timestart,
					string timeend,
					int math_number_questions,
					int fund_number_questions,
					int tech_number_questions,
					int math_correct_answers,
					int fund_correct_answers,
					int tech_correct_answers,
					double accuracy)
		{
			this.id = id;
			this.user_id = user_id;
			this.timestart = timestart;
			this.timeend = timeend;
			this.math_number_questions = math_number_questions;
			this.fund_number_questions = fund_number_questions;
			this.tech_number_questions = tech_number_questions;
			this.math_correct_answers = math_correct_answers;
			this.fund_correct_answers = fund_correct_answers;
			this.tech_correct_answers = tech_correct_answers;
			this.accuracy = accuracy;
		}
	}
}