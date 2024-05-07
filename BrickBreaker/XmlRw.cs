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
        public const int INVALID_FILE = 2;
        public const int XML_WRITE_ERR = 3;

        // Blocks from level
        public List<Block> blocks = new List<Block>();
        // Power-ups when they are added

        // High scores
        public List<int> highScores = new List<int>();

        // Keep track of level
        int level = -1;

        public XmlRw()
        {

        }

        public int writeStatistics(int blocksDestoryed, int score, int level)
        {
            XmlReader reader = XmlReader.Create("../../statistics.xml");

            int totalBlocksDestoryed = 0;
            int totalScore = 0;
            int highScore = 0;

            reader.ReadStartElement("statistics");

            while (reader.Read())
            {
                reader.ReadToFollowing("total_score");
                string totalScoreStr = reader.ReadString();
                if (totalScoreStr != null && totalScoreStr != "")
                {
                    totalScore = Convert.ToInt32(totalScoreStr);
                } else
                {
                    Console.WriteLine("oh no0!");
                }
                //totalScore = Convert.ToInt32(reader.ReadString());

                reader.ReadToFollowing("high_score");
                string highScoreStr = reader.ReadString();
                if (highScoreStr != null && highScoreStr != "")
                {
                    highScore = Convert.ToInt32(highScoreStr);
                } else
                {
                    Console.WriteLine("oh no1!");
                }

                reader.ReadToFollowing("blocks_destroyed");
                string blocksDestoryedStr = reader.ReadString();
                if (highScoreStr != null && highScoreStr != "")
                {
                    totalBlocksDestoryed = Convert.ToInt32(blocksDestoryedStr);
                } else
                {
                    Console.WriteLine("oh no2!");
                }

                //reader.ReadEndElement();
            }

            reader.Close();


            totalBlocksDestoryed += blocksDestoryed;
            totalScore += score;
            if (score >= highScore)
            {
                highScore = score;
            }
            Console.WriteLine($"xml file score: {totalScore}, highscore: {highScore}, blocks: {totalBlocksDestoryed}");

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlWriter writer = XmlWriter.Create("../../statistics.xml", settings);


            writer.WriteStartElement("statistics");
            writer.WriteStartElement("null", "null");
            writer.WriteElementString("total_score", totalScore.ToString());
            writer.WriteElementString("high_score", highScore.ToString());
            writer.WriteElementString("blocks_destroyed", totalBlocksDestoryed.ToString());
            writer.WriteEndElement();

            writer.Close();

            return SUCCESS;
        }

        public List<Block> allBlocks()
        {
            return blocks;
        }

        // TODO: When power-ups are added, add a "powerUp" argument
        public int saveLevel(string filePath, List<Block> blocks)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlWriter writer;

            try
            {
                writer = XmlWriter.Create($"../../levels/{filePath}", settings);
            }
            catch (System.IO.FileNotFoundException)
            {
                System.IO.File.Create($"../../levels/{filePath}");
                writer = XmlWriter.Create($"../../levels/{filePath}", settings);
            }

            writer.WriteStartElement("level");

            foreach (Block block in blocks)
            {
                writer.WriteStartElement("block");

                writer.WriteElementString("x", $"{block.x}");
                writer.WriteElementString("y", $"{block.y}");
                writer.WriteElementString("hp", $"{block.hp}");
                writer.WriteElementString("colour", $"{block.colour.ToKnownColor()}");

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
            if (filePath != null)
            {
                string levelNString = filePath.Replace("level", "").Replace(".xml", "");
                level = Convert.ToInt32(levelNString);
                Console.WriteLine($"level: {level}");
            }
            else
            {
                return INVALID_FILE;
            }

            blocks.Clear();

            XmlReader reader;

            try
            {
                reader = XmlReader.Create($"../../levels/{filePath}");
            }
            catch (System.IO.FileNotFoundException)
            {
                return INVALID_FILE;
            }
            catch (ArgumentNullException)
            {
                return INVALID_FILE;
            }

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

        // Call this method after a level is completed. If ``loadLevel`` is not called before it will return
        // ``INVALID_FILE`` (2)
        public int nextLevel()
        {
            if (level == -1)
            {
                return INVALID_FILE;
            }

            level += 1;

            return loadLevel($"level{level}.xml");
        }

        // -----
        // Level generation stuff
        // -----

        // Pyrimad thing
        public void triangleBlocks(bool upright, int width, int x, int y)
        {
            int minX = x;
            int maxX = x;

            if (upright)
            {
                for (int py = 0; py < width; py++)
                {
                    for (int px = minX; px < maxX; px++)
                    {
                        blocks.Add(new Block(px, py, 3, Color.Red));
                    }

                    minX -= 1;
                    maxX += 1;
                }
            }
        }

        public void bigBlock(int width, int x, int y)
        {
            for (int py = y; py < y + width; py++)
            {
                for (int px = x; px < x + width; px++)
                {
                    blocks.Add(new Block(px, py, 5, Color.Red));
                }
            }
        }

        public void line(bool horizontal, int length, int x, int y)
        {
            if (horizontal)
            {
                for (int p = 0; p < length; p++)
                {
                    blocks.Add(new Block(x + p, y, 1, Color.Red));
                }
            }
            else
            {
                for (int p = 0; p < length; p++)
                {
                    blocks.Add(new Block(x, y + p, 1, Color.Red));
                }
            }
        }
    }
}
