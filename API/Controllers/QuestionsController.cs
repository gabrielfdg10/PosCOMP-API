﻿using API.Models;
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
	public class QuestionsController : ApiController
    {

		[HttpGet]
		[Route("api/questions/getQuestionsByClass/{c}/{q}")]
		public List <Question> getQuestions(string c, int q)
		{
			List<Question> results = new List<Question>();
			List<Question> finalResults = new List<Question>();

			MySqlConnection conn = WebApiConfig.conn();
			MySqlCommand query = conn.CreateCommand();
			query.CommandText = "SELECT * from QUESTION where category=@c";
			query.Parameters.AddWithValue("@c", c);
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
				results.Add(new Question(Int32.Parse(fetch["id"].ToString()), fetch["statement"].ToString(),
									fetch["alt_a"].ToString(), fetch["alt_b"].ToString(),
									fetch["alt_c"].ToString(), fetch["alt_d"].ToString(),
									fetch["alt_e"].ToString(), fetch["answer"].ToString(),
									fetch["identifier"].ToString(), fetch["category"].ToString(),
									fetch["second_statement"].ToString(), fetch["url"].ToString()));
			}

			Random random = new Random();
			for (int i = 0; i < q; i++)
			{
				int index = random.Next(results.Count);
				Question quest = results[index];
				results.RemoveAt(index);
				finalResults.Add(quest);
			}

			return finalResults;
		}

		[HttpPost]
		[Route("api/questions/newQuestion")]
		public IHttpActionResult newQuestion([FromBody] Question question)
		{
			MySqlConnection conn = WebApiConfig.conn();
			MySqlCommand query = conn.CreateCommand();
			conn.Open();

			query.CommandText = "INSERT into QUESTION (statement, alt_a, alt_b, alt_c, alt_d, alt_e, answer, identifier, second_statement, category, url) values (@statement, @alt_a, @alt_b, @alt_c, @alt_d, @alt_e, @answer, @identifier, @second_statement, @category, @url);";
			query.Parameters.AddWithValue("@statement", question.statement);
			query.Parameters.AddWithValue("@alt_a", question.alt_a);
			query.Parameters.AddWithValue("@alt_b", question.alt_b);
			query.Parameters.AddWithValue("@alt_c", question.alt_c);
			query.Parameters.AddWithValue("@alt_d", question.alt_d);
			query.Parameters.AddWithValue("@alt_e", question.alt_e);
			query.Parameters.AddWithValue("@answer", question.answer);
			query.Parameters.AddWithValue("@identifier", question.identifier);
			query.Parameters.AddWithValue("@second_statement", question.second_statement);
			query.Parameters.AddWithValue("@category", question.category);
			query.Parameters.AddWithValue("@url", question.url);


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

		[HttpDelete]
		[Route("api/questions/deleteQuestion/{identifier}")]
		public IHttpActionResult deleteQuestion(string identifier)
		{
			MySqlConnection conn = WebApiConfig.conn();
			MySqlCommand query = conn.CreateCommand();
			conn.Open();

			query.CommandText = "DELETE FROM QUESTION WHERE identifier = @identifier";
			query.Parameters.AddWithValue("@identifier", identifier);
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

		/*
		[HttpPost]
		[Route("api/questions/changeQuestionInformation")]
		public IHttpActionResult changeQuestionInformation([FromBody] Question question)
		{
			MySqlConnection conn = WebApiConfig.conn();
			MySqlCommand query = conn.CreateCommand();
			conn.Open();

			query.CommandText = "UPDATE QUESTION SET statement=@statement, alt_a=@alt_a, alt_b=@alt_b, alt_c=@alt_c, alt_d=@alt_d, alt_e=@alt_e, answer=@answer, second_statement=@second_statement, category=@category) where identifier=@identifier;";
			query.Parameters.AddWithValue("@statement", question.statement);
			query.Parameters.AddWithValue("@alt_a", question.alt_a);
			query.Parameters.AddWithValue("@alt_b", question.alt_b);
			query.Parameters.AddWithValue("@alt_c", question.alt_c);
			query.Parameters.AddWithValue("@alt_d", question.alt_d);
			query.Parameters.AddWithValue("@alt_e", question.alt_e);
			query.Parameters.AddWithValue("@answer", question.answer);
			query.Parameters.AddWithValue("@identifier", question.identifier);
			query.Parameters.AddWithValue("@second_statement", question.second_statement);
			query.Parameters.AddWithValue("@category", question.category);

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
		}*/
	}
}
