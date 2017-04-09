using Newtonsoft.Json.Linq;
using System;
using Newtonsoft.Json;

namespace JsonConversion
{
	class JsonProgram
	{
		static void Main()
		{
			string json = Console.In.ReadToEnd();
			JsonV2 v2 = JsonConvert.DeserializeObject<JsonV2>(json);
			//...
			var v3 = Convertor.Convert(v2);
			Console.Write(JsonConvert.SerializeObject(v3));
		}
	}
}
