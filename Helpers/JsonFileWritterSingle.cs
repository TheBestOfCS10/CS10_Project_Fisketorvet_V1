using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CS10_Project_Fisketorvet_V1.Helpers
{
    public class JsonFileWritterSingle<T>
    {
        public static void WriteToJson(T objects, string JsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(objects,
                                                               Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(JsonFileName, output);
        }

    }
}
