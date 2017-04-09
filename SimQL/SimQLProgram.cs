using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SimQLTask
{
	class SimQLProgram
	{
		static void Main(string[] args)
		{
			var json = Console.In.ReadToEnd();
			foreach (var result in ExecuteQueries(json).ToArray())
				Console.WriteLine(result);
		}

		public static IEnumerable<string> ExecuteQueries(string json)
		{
			var jObject = JObject.Parse(json);
			var data = (JObject)jObject["data"];
			var queries = jObject["queries"].ToObject<string[]>();
		    foreach (var query in queries)
		    {
		        var path = query.Split('.');
		        JToken result= data;
		        try
		        {
		            foreach (var s in path)
		            {
		                result = result[s];
		            }
		            result = $"{query} = {result?.ToString().Replace(',', '.')}";

		        }
		        catch (Exception e)
		        {
		            result = "";
		        }
		        yield return result.ToString();
            }

			//return queries.Select(q => "TODO");
		}
	}
}
