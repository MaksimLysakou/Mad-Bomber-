using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Mad_Bomber_
{
    class XML
    {
        private static List<GameObj> getListOfGameObj(string pathToGameObjXML)
        {
            XDocument doc = XDocument.Load(pathToGameObjXML);
            List<GameObj> gameObjs = new List<GameObj>();
            gameObjs.Add(new GameObj());

                foreach (XElement obj in doc.Root.Elements())
                {
                    gameObjs.Add(new GameObj(obj.Attribute("path").Value));
                }

            return gameObjs;
        }
        public static List<Level> getListOfLevels(string pathToLevelXML, string pathToGameObjXML)
        {
            XDocument doc = XDocument.Load(pathToLevelXML);
            List<GameObj> gameObjs = getListOfGameObj(pathToGameObjXML);

            List<Level> levels = new List<Level>();            

            foreach (XElement level in doc.Root.Elements())
            {
                Level thisLevel = new Level("");

                thisLevel.size.X = int.Parse(level.Attribute("sizeX").Value);
                thisLevel.size.Y = int.Parse(level.Attribute("sizeY").Value);

                thisLevel.Name = level.Attribute("name").Value;

                foreach (XElement block in level.Elements())
                {
                    thisLevel.blocks.Add(new Block(gameObjs[int.Parse(block.Attribute("type").Value)],
                                                   float.Parse(block.Attribute("X").Value),
                                                   float.Parse(block.Attribute("Y").Value),
                                                   bool.Parse(block.Attribute("destroyable").Value),
                                                   bool.Parse(block.Attribute("passeble").Value)
                                                  )
                                        );
                }

                levels.Add(thisLevel);
            }

            return levels;
        }
    }
}
