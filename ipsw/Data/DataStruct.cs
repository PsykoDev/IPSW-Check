using System;
namespace ipsw.Data
{
    public class DataStruct
    {
		// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Firmware
        {
            public string identifier { get; set; }
            public string version { get; set; }
            public string buildid { get; set; }
            public string sha1sum { get; set; }
            public string md5sum { get; set; }
            public object filesize { get; set; }
            public string url { get; set; }
            public DateTime releasedate { get; set; }
            public DateTime uploaddate { get; set; }
            public bool signed { get; set; }
        }

        public class Board
        {
            public string boardconfig { get; set; }
            public string platform { get; set; }
            public int cpid { get; set; }
            public int bdid { get; set; }
        }

        public class Root
        {
            public string name { get; set; }
            public string identifier { get; set; }
            public List<Firmware> firmwares { get; set; }
            public List<Board> boards { get; set; }
            public string boardconfig { get; set; }
            public string platform { get; set; }
            public int cpid { get; set; }
            public int bdid { get; set; }
        }

    }

    public class Finder
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class BoardFinder
        {
            public string Boardconfig { get; set; }
            public string Platform { get; set; }
            public int Cpid { get; set; }
            public int Bdid { get; set; }
        }

        public class RootFinder
        {
            public string Name { get; set; }
            public string Identifier { get; set; }
            public List<BoardFinder> Boards { get; set; }
            public string Boardconfig { get; set; }
            public string Platform { get; set; }
            public int Cpid { get; set; }
            public int Bdid { get; set; }
        }
    }
}

