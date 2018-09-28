using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;

namespace API.Controllers
{
    public class UsersController : ApiController
	{
		private static List<User> users = new List<User>();
		
		[HttpGet]
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
				results.Add(new User(-1, null, null, ex.ToString()));
			}
			MySqlDataReader fetch= query.ExecuteReader();
			while (fetch.Read())
			{
				results.Add(new User(Int32.Parse(fetch["id"].ToString()), fetch["username"].ToString(), fetch["password"].ToString(), null));
			}
			return results;
		}

		[HttpPost]
		public IHttpActionResult insertUser([FromBody] User user)
		{
			if(user != null && user.userName != null && user.passWord != null)
			{
				users.Add(new User(user.id, user.userName, user.passWord, null));
				return Ok();	
			}
			return BadRequest();	

		}
		[HttpDelete]
		public IHttpActionResult deleteUser(int id)
		{
			
			users.RemoveAt(users.IndexOf(users.First(x => x.id == id)));
			return Ok();
		}
	}
}
