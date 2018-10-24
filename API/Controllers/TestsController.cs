using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using API.Models;
using System.Web.Http.Cors;

namespace API.Controllers
{
	public class TestsController : ApiController
    {
		[HttpGet]
		[Route("api/tests/getTestByUser/{user_id}")]
		public List<Test> getTestByUser(int user_id)
		{
			List<Test> results = new List<Test>();

			MySqlConnection conn = WebApiConfig.conn();
			MySqlCommand query = conn.CreateCommand();
			query.CommandText = "SELECT * from test where user_id=@user_id";
			query.Parameters.AddWithValue("@user_id", user_id);
			try
			{
				conn.Open();
			}
			catch (MySql.Data.MySqlClient.MySqlException ex)
			{
				Console.WriteLine(ex);
			}
			MySqlDataReader fetch = query.ExecuteReader();
			while (fetch.Read())
			{
				results.Add(new Test(Int32.Parse(fetch["id"].ToString()),
									Int32.Parse(fetch["user_id"].ToString()),
									fetch["timestart"].ToString(),
									fetch["timeend"].ToString(),
									Int32.Parse(fetch["math_number_questions"].ToString()),
									Int32.Parse(fetch["fund_number_questions"].ToString()),
									Int32.Parse(fetch["tech_number_questions"].ToString()),
									Int32.Parse(fetch["math_correct_answers"].ToString()),
									Int32.Parse(fetch["fund_correct_answers"].ToString()),
									Int32.Parse(fetch["tech_correct_answers"].ToString()),
									double.Parse(fetch["accuracy"].ToString()) ));
			}
			return results;
		}

		[HttpPost]
		[Route("api/tests/newTest")]
		public IHttpActionResult newTest([FromBody] Test test)
		{
			MySqlConnection conn = WebApiConfig.conn();
			MySqlCommand query = conn.CreateCommand();
			conn.Open();

			query.CommandText = "INSERT into test (user_id, timestart, timeend, math_number_questions, fund_number_questions, tech_number_questions, math_correct_answers, fund_correct_answers, tech_correct_answers, accuracy) values (@user_id, @timestart, @timeend, @math_number_questions, @fund_number_questions, @tech_number_questions, @math_correct_answers, @fund_correct_answers, @tech_correct_answers, @accuracy);";
			query.Parameters.AddWithValue("@user_id", test.user_id);
			query.Parameters.AddWithValue("@timestart", test.timestart);
			query.Parameters.AddWithValue("@timeend", test.timeend);
			query.Parameters.AddWithValue("@math_number_questions", test.math_number_questions);
			query.Parameters.AddWithValue("@fund_number_questions", test.fund_number_questions);
			query.Parameters.AddWithValue("@tech_number_questions", test.tech_number_questions);
			query.Parameters.AddWithValue("@math_correct_answers", test.math_correct_answers);
			query.Parameters.AddWithValue("@fund_correct_answers", test.fund_correct_answers);
			query.Parameters.AddWithValue("@tech_correct_answers", test.tech_correct_answers);
			query.Parameters.AddWithValue("@accuracy", test.accuracy);

			try
			{
				query.ExecuteNonQuery();
				conn.Close();

				return Ok();

			}
			catch (MySql.Data.MySqlClient.MySqlException ex)
			{
				conn.Close();
				return BadRequest();

			}
		}
	}
}
