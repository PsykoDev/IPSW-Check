using System;
using System.Collections.Generic;
using System.Linq;
using ipsw.Data.Request;
using ipsw.Data.build;

namespace ipsw
{
    public class Program
    {
        internal static string Identifier = "iPhone11,6"; // let empty to find your iphone Identifier

        public static async Task Main(string[] args)
        {
            if (Program.Identifier != string.Empty)
            {
                string result = await Request.Http();
                BuildData.Build(result);
                Console.ReadKey();
            }
            else
            {
                string result = await Request.Find();
                BuildData.BuildFind(result);
                Console.ReadKey();
            }
        }
    }
}