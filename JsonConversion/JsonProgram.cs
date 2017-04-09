using Newtonsoft.Json.Linq;
using System;
using Newtonsoft.Json;

namespace JsonConversion
{
	class JsonProgram
	{
		static void Main()
		{
			var json = Console.In.ReadToEnd();
			var v2 = JsonConvert.DeserializeObject<JsonV2>(json);
			//...
			var v3 = Convertor.Convert(v2);
			Console.Write(v3);
		}
	}
}
