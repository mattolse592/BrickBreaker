using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Drawing;

namespace BrickBreaker
{
    internal class XmlRw
    {
        // Indications
        public const int SUCCESS = 0;
        public const int XML_READ_ERR = 1;

        // Blocks from level
        public List<Block> blocks = new List<Block>();
        // Power-ups when they are added

        // High scores
        public List<int> highScores = new List<int>();

        public XmlRw()
        {

        }

        // TODO: When power-ups are added, add a "powerUp" argument
        public int saveLevel(string filePath, List<Block> blocks)
        {
            XmlWriter writer = XmlWriter.Create($"../../levels/{filePath}");
            //writer.Settings.Indent = true;

            writer.WriteStartElement("level");

            foreach (Block block in blocks)
            {
                writer.WriteStartElement("block");

                writer.WriteElementString("x", $"{block.x}");
                writer.WriteElementString("y", $"{block.y}");
                writer.WriteElementString("hp", $"{block.hp}");
                writer.WriteElementString("colour", block.colour.ToString());

                writer.WriteEndElement();
            }

            /* foreach PowerUp powerup in powerups
             *  writer.WriteStartElement("powerup")
             *  writer.write_the_data
             *  writer.WriteEndElement();
             */

            writer.WriteEndElement();
            writer.Close();
            return SUCCESS;
        }

        // Call "levelN.xml" or "level_saveN.xml"
        public int loadLevel(string filePath)
        {
            XmlReader reader = XmlReader.Create($"../../levels/{filePath}");

            reader.ReadStartElement("level");

            while (reader.Read())
            {
                Block block = new Block(0, 0, 0, Color.Black);
                if (reader.ReadToNextSibling("block") == false)
                {
                    if (reader.ReadToNextSibling("powerup") == false)
                    {
                        return XML_READ_ERR;
                    }
                    // Generate powerups
                }

                // x
                reader.ReadToFollowing("x");
                string x = reader.ReadString();
                if (x != "" || x != null)
                {
                    block.x = Convert.ToInt32(x);
                }

                // y
                if (reader.ReadToNextSibling("y") == false)
                {
                    return XML_READ_ERR;
                }

                string y = reader.ReadString();
                if (y != "" || y != null)
                {
                    block.y = Convert.ToInt32(y);
                }

                // hp
                if (reader.ReadToNextSibling("hp") == false)
                {
                    return XML_READ_ERR;
                }
                string hp = reader.ReadString();

                if (hp != "" || hp != null)
                {
                    block.hp = Convert.ToInt32(hp);
                }

                // colour
                if (reader.ReadToNextSibling("colour") == false)
                {
                    return XML_READ_ERR;
                }
                string colour = reader.ReadString();
                block.colour = Color.FromName(colour);

                Console.WriteLine($"x: {block.x}, y: {block.y}, hp: {block.hp}, color: {block.colour}");
                blocks.Add(block);
                reader.ReadEndElement();
            }

            return SUCCESS;
        }
    }
}
