﻿using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;

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
												Int32.Parse(fetch["question_id"].ToString())));
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
												Int32.Parse(fetch["question_id"].ToString())));
			}
			return results;
		}

		[HttpPost]
		[Route("api/qot/newRelation/{test_id}/{question_id}")]
		public IHttpActionResult newUser(string test_id, string question_id)
		{
			MySqlConnection conn = WebApiConfig.conn();
			MySqlCommand query = conn.CreateCommand();
			conn.Open();

			query.CommandText = "INSERT into question_on_test (test_id, question_id) values (@test_id, @question_id);";
			query.Parameters.AddWithValue("@test_id", test_id);
			query.Parameters.AddWithValue("@question_id", question_id);

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