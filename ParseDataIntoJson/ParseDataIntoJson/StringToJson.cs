using Newtonsoft.Json.Linq;
using ParseDataIntoJson.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using ParseDataIntoJson.Model;


namespace ParseDataIntoJson
{
    internal class StringToJson
    {
        static void Main()
        {
            DataModel dataModel = new DataModel();

            string[] plantsArray = File.ReadAllLines(@"C:\Users\magda\source\repos\plants-for-cats\ParseDataIntoJson\PlantsSafeForAnimals.txt");

            foreach(var line in plantsArray)
            {
                dataModel.Name = plantsArray[1]
            }
            
        }
    }
}
