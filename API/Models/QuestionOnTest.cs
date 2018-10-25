using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
	public class QuestionOnTest
	{
		public int test_id { get; set; }
		public int question_id { get; set; }
		public int correct { get; set; }
		public QuestionOnTest(int test_id, int question_id, int correct)
		{
			this.test_id = test_id;
			this.question_id = question_id;
			this.correct = correct;
		}
	}
}