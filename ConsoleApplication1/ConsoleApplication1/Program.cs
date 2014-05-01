using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace ConsoleApplication1
{
    class Toto
    {
    }
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument document = new XmlDocument();
            document.Load(@"D:\sprites\tileset\example.tmx");

            XmlNodeList nodes = document.GetElementsByTagName("tileset");
            List<TileSet> tileSets = new List<TileSet>();
            foreach (XmlNode node in nodes)
            {
                int firstGid = Convert.ToInt32(node.Attributes["firstgid"].InnerText);
                String name = node.Attributes["name"].InnerText;
                int tileWidth = Convert.ToInt32(node.Attributes["tilewidth"].InnerText);
                int tileHeight = Convert.ToInt32(node.Attributes["tileheight"].InnerText);

                XmlNode imgNode = node.FirstChild;
                String src = imgNode.Attributes["source"].InnerText;
                int imgWidth = Convert.ToInt32(imgNode.Attributes["width"].InnerText);
                int imgHeight = Convert.ToInt32(imgNode.Attributes["height"].InnerText);

                TileSet tileSet = new TileSet(firstGid, name, tileWidth, tileHeight, src, imgWidth, imgHeight);
                tileSets.Add(tileSet);
            }
            String toto = null;
            foreach (TileSet tileSet in tileSets)
            {
                if (toto == null)
                {
                    Console.WriteLine("hodooor");
                    toto = "hoodoooor";
                    Console.WriteLine(10 * .05f);
                }
                Console.WriteLine(tileSet.TileHeight);
            }

        }
    }
    public class TileSet
    {
        public int FirstGid { get; set; }
        public int LastGid { get; set; }
        public String Name { get; set; }
        public int TileWidth { get; set; }
        public String Source { get; set; }
        public int TileHeight { get; set; }
        public int ImageWidth { get; set; }
        public int ImageHeight { get; set; }
        //public Texture2D texture { get; set; } 
        public int TileAmountWidth { get; set; }
 
        public TileSet(int FirstGid, String Name, int TileWidth, int TileHeight, String Source, int ImageWidth, int ImageHeight)
       {
          this.FirstGid = FirstGid;
          this.Name = Name;
          this.TileWidth = TileWidth;
          this.TileHeight = TileHeight;
          this.Source = Source;
          this.ImageWidth = ImageWidth;
          this.ImageHeight = ImageHeight;
          TileAmountWidth = (int) Math.Floor((double) (ImageWidth / TileWidth));
          LastGid = TileAmountWidth * (int) Math.Floor((double) (ImageHeight / TileHeight)) + FirstGid - 1;
       }
    }
}