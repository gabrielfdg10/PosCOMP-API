using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using System.Web.Http.Cors;

namespace API.Controllers
{
	public class QoTController : ApiController
    {
		[HttpGet]
		[Route("api/qot/getRelationsByTestId/{test_id}")]
		public List<QuestionOnTest> getRelationsByTestId(int test_id)
		{
			List<QuestionOnTest> results = new List<QuestionOnTest>();

			MySqlConnection conn = WebApiConfig.conn();
			MySqlCommand query = conn.CreateCommand();
			query.CommandText = "SELECT * from question_on_test where test_id=@test_id";
			query.Parameters.AddWithValue("@test_id", test_id);
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
				results.Add(new QuestionOnTest(Int32.Parse(fetch["test_id"].ToString()),
												Int32.Parse(fetch["question_id"].ToString()),
												Int32.Parse(fetch["correct"].ToString()) 
											));
			}
			return results;
		}

		[HttpGet]
		[Route("api/qot/getRelationsByQuestionId/{question_id}")]
		public List<QuestionOnTest> getRelationsByQuestionId(int question_id)
		{
			List<QuestionOnTest> results = new List<QuestionOnTest>();

			MySqlConnection conn = WebApiConfig.conn();
			MySqlCommand query = conn.CreateCommand();
			query.CommandText = "SELECT * from question_on_test where question_id=@question_id";
			query.Parameters.AddWithValue("@question_id", question_id);
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
				results.Add(new QuestionOnTest(Int32.Parse(fetch["test_id"].ToString()),
												Int32.Parse(fetch["question_id"].ToString()),
												Int32.Parse(fetch["correct"].ToString())
												));
			}
			return results;
		}

		[HttpPost]
		[Route("api/qot/newRelation")]
		public string newUser([FromBody] QuestionOnTest qot)
		{
			MySqlConnection conn = WebApiConfig.conn();
			MySqlCommand query = conn.CreateCommand();
			conn.Open();

			query.CommandText = "INSERT into question_on_test (test_id, question_id, correct) values (@test_id, @question_id, @correct);";
			query.Parameters.AddWithValue("@test_id", qot.test_id);
			query.Parameters.AddWithValue("@question_id", qot.question_id);
			query.Parameters.AddWithValue("@correct", qot.correct);


			try
			{
				query.ExecuteNonQuery();
				conn.Close();

				return "certo";

			}
			catch (MySql.Data.MySqlClient.MySqlException ex)
			{
				conn.Close();
				return "erro";

			}
		}

	}
}
