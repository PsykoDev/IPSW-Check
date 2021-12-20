using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static ipsw.Data.DataStruct;
using static ipsw.Data.Finder;
#pragma warning disable CS8600
namespace ipsw.Data.build
{
	public class BuildData
	{
        private static JArray? JArray;

        internal static void Build(string json)
        {
            Root mdc = JsonConvert.DeserializeObject<Root>(json);
			Console.WriteLine($"Search for {mdc.name} | {mdc.identifier}");
            Console.Write("--------------------------------------------------\n\n");
            for (int i = 0; i< mdc.firmwares.Count; i++)
            {
				Firmware result = mdc.firmwares[i];
				if(result.signed == true)
                {
					var print = $"Version: {result.version} | Size: {SizeSuffix((long)result.filesize, 2)} | Signed: {result.signed}\n" +
						$"Url: {result.url}\n";
					Console.WriteLine(print);
                }
            }
        }

        static string SizeSuffix(Int64 value, int decimalPlaces = 1)
        {
            string[] SizeSuffixes = { "bytes", "KB", "MB", "GB" };
            if (decimalPlaces < 0) { throw new ArgumentOutOfRangeException("decimalPlaces"); }
            if (value < 0) { return "-" + SizeSuffix(-value, decimalPlaces); }
            if (value == 0) { return string.Format("{0:n" + decimalPlaces + "} bytes", 0); }
            int mag = (int)Math.Log(value, 1024);
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));
            if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
            { mag += 1; adjustedSize /= 1024; }
            return string.Format("{0:n" + decimalPlaces + "} {1}",
                adjustedSize,
                SizeSuffixes[mag]);
        }

        internal static void BuildFind(string json)
        {
            JArray = JArray.Parse(json);
            PrintLine();
            PrintRow("Name", "Identifier");
            PrintRow("", "");
            PrintLine();
            for (int i = 0; i<JArray.Count(); i++)
            {
                RootFinder mdc = JsonConvert.DeserializeObject<RootFinder>(JArray[i].ToString());
                var arg0 = mdc.Name;
                var arg1 = mdc.Identifier;
                print(arg0, arg1);
            }
        }

        static int tableWidth = 90;
        static void print(string arg, string arg1)
        {
            PrintRow($"{arg}", $"{arg1}");
            PrintLine();
        }

        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}

