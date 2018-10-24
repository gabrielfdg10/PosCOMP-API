using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MySql.Data.MySqlClient;
using System.Web.Http.Cors;

namespace API
{
    public static class WebApiConfig
    {

		public static MySqlConnection conn()
		{
			string conn_string = "Server=localhost; Port=3306; Database=poscomp; Uid=root; Password=franco123;";
			MySqlConnection conn = new MySqlConnection(conn_string);
			return conn;
		}

        public static void Register(HttpConfiguration config)
        {
			// Web API configuration and services
			var cors = new EnableCorsAttribute("*", "*", "*");
			config.EnableCors(cors);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
