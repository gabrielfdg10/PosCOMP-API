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
	public class UsersController : ApiController
	{
		
		[HttpGet]
		[Route("api/users/getUsers")]
		public List <User> getUsers()
		{
			List<User> results = new List<User>();

			MySqlConnection conn = WebApiConfig.conn();
			MySqlCommand query = conn.CreateCommand();
			query.CommandText = "SELECT * from USER";
			try
			{
				conn.Open();
			}
			catch (MySql.Data.MySqlClient.MySqlException ex)
			{
				Console.WriteLine(ex);
			}
			MySqlDataReader fetch= query.ExecuteReader();
			while (fetch.Read())
			{
				results.Add(new User(Int32.Parse(fetch["id"].ToString()), fetch["member_since"].ToString(), 
									fetch["username"].ToString(), fetch["email"].ToString(), 
									fetch["password"].ToString(), fetch["real_name"].ToString(),
									fetch["institution"].ToString()));
			}
			return results;
		}
		
		[HttpGet]
		[Route("api/users/getUsersStats/{id}")]
		public Stats UserStats(int id)
		{
			QoTController qotController = new QoTController();
			TestsController testsController = new TestsController();
			List<QuestionOnTest> qotList = new List<QuestionOnTest>();
			List<Test> testList = new List<Test>();
			Stats userStats = new Stats(id, 0, 0, 0, 0, 0, 0, 0, 0, 0);
			testList = testsController.getTestByUser(id);
			for(int i = 0; i < testList.Count; i++)
			{
				userStats.test_made++;
				switch (testList[i].type)
				{
					case "Simulado Personalizado":
						userStats.custom_test++;
						break;
					case "Simulado Aleatório":
						userStats.random_test++;
						break;

				}
				qotList = qotController.getRelationsByTestId(testList[i].id);
				for(int j = 0; j < qotList.Count; j++)
				{
					switch (qotList[j].question_type)
					{
						case "math":
							userStats.math_ans++;
							if (qotList[j].correct == 1) userStats.math_cor++;
							break;
						case "tech":
							userStats.tech_ans++;
							if (qotList[j].correct == 1) userStats.tech_cor++;
							break;
						case "fund":
							userStats.fund_ans++;
							if (qotList[j].correct == 1) userStats.fund_cor++;
							break;
					}
				}
			}
			return userStats;
		}

		[HttpGet]
		[Route("api/users/logInUser/{username}/{password}")]
		public List <User> logInUser(string username, string password)
		{

			List<User> results = new List<User>();
			MySqlConnection conn = WebApiConfig.conn();
			MySqlCommand query = conn.CreateCommand();
			query.CommandText = "SELECT * from USER where username = @username and password = @password";
			query.Parameters.AddWithValue("@username", username);
			query.Parameters.AddWithValue("@password", password);

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
				results.Add(new User(Int32.Parse(fetch["id"].ToString()), fetch["member_since"].ToString(),
									fetch["username"].ToString(), fetch["email"].ToString(),
									fetch["password"].ToString(), fetch["real_name"].ToString(),
									fetch["institution"].ToString()));
			}
			return results;
		}

		[HttpPost]
		[Route("api/users/newUser")]
		public IHttpActionResult newUser([FromBody] User user)
		{
			MySqlConnection conn = WebApiConfig.conn();
			MySqlCommand query = conn.CreateCommand();
			conn.Open();

			query.CommandText = "INSERT into USER (member_since, username, email, password, real_name, institution) values (@member_since, @username, @email, @password, @real_name, @institution);";
			query.Parameters.AddWithValue("@member_since", user.member_since);
			query.Parameters.AddWithValue("@username", user.username);
			query.Parameters.AddWithValue("@email", user.email);
			query.Parameters.AddWithValue("@password", user.password);
			query.Parameters.AddWithValue("@real_name", user.real_name);
			query.Parameters.AddWithValue("@institution", user.institution);
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

		[HttpPost]
		[Route("api/users/changeUserInformation")]
		public IHttpActionResult changeUserInformation ([FromBody] User user)
		{
			MySqlConnection conn = WebApiConfig.conn();
			MySqlCommand query = conn.CreateCommand();
			conn.Open();
			query.CommandText = "UPDATE USER SET email=@email, password=@password, real_name=@real_name, institution=@institution WHERE id=@id;";
			query.Parameters.AddWithValue("@id", user.id);
			query.Parameters.AddWithValue("@email", user.email);
			query.Parameters.AddWithValue("@password", user.password);
			query.Parameters.AddWithValue("@real_name", user.real_name);
			query.Parameters.AddWithValue("@institution", user.institution);
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
		[Route("api/users/deleteUser/{id}")]
		public IHttpActionResult deleteUser(int id)
		{
			MySqlConnection conn = WebApiConfig.conn();
			MySqlCommand query = conn.CreateCommand();
			conn.Open();

			query.CommandText = "DELETE FROM USER WHERE id = @id";
			query.Parameters.AddWithValue("@id", id);
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
