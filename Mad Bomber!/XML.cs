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

                thisLevel.Name = level.Attribute("name").Value;

                foreach (XElement block in level.Elements())
                {

                    GameObj g = gameObjs[int.Parse(block.Attribute("type").Value)];
                    float a = float.Parse(block.Attribute("X").Value);
                    float b = float.Parse(block.Attribute("Y").Value);
                    bool q = bool.Parse(block.Attribute("destroyable").Value);
                    bool z = bool.Parse(block.Attribute("passeble").Value);

                    thisLevel.blocks.Add(new Block(g, a, b, q, z));
                }

                levels.Add(thisLevel);
            }

            return levels;
        }
    }
}
