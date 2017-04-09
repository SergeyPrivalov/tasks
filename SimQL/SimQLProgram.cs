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
		    return ProccesQuery(queries, data);
		}

	    private static IEnumerable<string> ProccesQuery(string[] queries, JObject data)
	    {
            var commandDictionary = new Dictionary<string,Func<List<JToken>, double>>();
	        commandDictionary.Add("sum", list => list.Sum(x => (double) x));
	        commandDictionary.Add("min", list => list.Min(x => (double) x));
	        commandDictionary.Add("max", list => list.Max(x => (double) x));
	        foreach (var query in queries)
	        {
	            var splitedQuery = ParseQuery(query);
	            var path = splitedQuery.Item1.Split('.');
	            var results = new List<JToken> { data };
	            var result = $"{query}";
	            try
	            {
	                foreach (var s in path)
	                {
	                    results = results.SelectMany(x => MakeStepIntoStruck(x, s)).ToList();
	                }
	                if (results.Count == 1 && results.First().Type != JTokenType.Array)
	                {
	                    var elemenet = results.First();
	                    if (elemenet is JValue)
	                    {
	                        result = $"{query} = {elemenet.ToString().Replace(',', '.')}";
	                    }
	                }
	                else if (results.First().Type == JTokenType.Array)
	                {
	                   var array = results.First().Children().ToList();
	                    result = $"{query} = {commandDictionary[splitedQuery.Item2](array).ToString().Replace(',','.')}";
	                }
	                else if (results.Count > 1)
	                {
	                    result = $"{query} = {commandDictionary[splitedQuery.Item2](results)}";
	                }

	            }
	            catch (Exception e)
	            {
	                result = $"{query}";
	            }
	            yield return result;
	        }
        }

	    private static IEnumerable<JToken> MakeStepIntoStruck(JToken place, string key)
	    {
	        if (place.Type == JTokenType.Array)
	        {
	            var arrayOfElements = (JArray) place;
	            foreach (var elemnt in arrayOfElements)
	            {
	                yield return elemnt[key];
	            }
	        }
	        else
	        {
	            yield return place[key];
	        }
	    }

	    private static Tuple<string, string> ParseQuery(string query)
	    {
	        var result = query.Split('(', ')');
	        return result.Length == 1 ? Tuple.Create(result.First(), "") : Tuple.Create(result[1], result[0]);
	    }
	}
}
