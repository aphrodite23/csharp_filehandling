using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GDP
{
    public class Program
    {
        
          public static void Main(){
            List<string[]> s= new List<string []>();
            var reader=new StreamReader(@"C:\Users\CGI\Desktop\C#_fund\gdp\data\datafile.csv");
            string convertJsonPath = @"../data/db.json";
            while(!reader.EndOfStream){
                var line=reader.ReadLine();
                var values=(line.Replace("\"","").Split(','));
                s.Add(values);
            }


            Console.WriteLine(Directory.GetCurrentDirectory());
           
               
            
              
                var dict = new Dictionary<string,string>();
                if(File.Exists(convertJsonPath)){
                    using (StreamReader file= File.OpenText(convertJsonPath))
                    using (JsonTextReader read=new JsonTextReader(file))
                    {
                        JToken ob = JToken.ReadFrom(read);
                        foreach(var i in ob){
                            dict.Add((string)i["country"],(string)i["continent"]);
                        }
                    }
                   
                } 
               
               
                var fin=new Dictionary<string,Dictionary<string,decimal>>();
               for(int i=0;i<s.Count;i++){
                    var country= s[i][0];
                    string continent;
                    if(dict.ContainsKey(country)){
                        continent = dict[country];
                        if(fin.ContainsKey(continent)){
                            fin[continent]["GDP_2012"]+=Decimal.Parse(s[i][7]);
                            fin[continent]["POPULATION_2012"]+=Decimal.Parse(s[i][4]);
                        }
                       
                        else
                        {
                        fin[continent]= new Dictionary<string,decimal>();
                        fin[continent].Add("GDP_2012",Decimal.Parse(s[i][7]));
                        fin[continent].Add("POPULATION_2012",Decimal.Parse(s[i][4]));
                    }
                    }
               }
                // foreach(var items in fin){
                //     Console.WriteLine($"{items.Key}");
                //     foreach(var item in items.Value){
                //         Console.WriteLine($"{item.Key} {item.Value}");
                //     }
                    
                // }
                string json = JsonConvert.SerializeObject(fin,Formatting.Indented);
                //Console.WriteLine(json);
                string path=@"C:\Users\CGI\Desktop\C#_fund\gdp\output\output.json";
                using(var tw=new StreamWriter(path,true)){
                    tw.WriteLine(json.ToString());
                    tw.Close();
                }

                // JObject xpctJSON = JObject.Parse(@"C:\Users\CGI\Desktop\C#_fund\gdp1\GDP.Tests\expected.json");
                //  JObject actJSON = JObject.Parse(@"C:\Users\CGI\Desktop\C#_fund\gdp1\output\output.json");
                //  //bool res = JToken.DeepEquals(xpctJSON, actJSON);
                //  //Console.WriteLine(res);
                //  actJSON.Should().BeEquivalentTo(xpctJSON);
               }
            
        }
        
}
    

