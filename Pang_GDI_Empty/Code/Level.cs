using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePang
{
    public class Level
    {
        public string mBackgroundTextureName = "";
        public SMX.Maths.Vector2 mPlayerInitialPosition;
        public List<Ball> mBalls = new List<Ball>();

        public void onFrameMove()
        {

            foreach (Ball b in mBalls)
            {
                b.OnFrameMove();
            }

        }

        public void onFrameRender()
        {

            Game.mRenderer.DrawSprite(mBackgroundTextureName,0,0,Game.DefaultGameWidth,Game.DefaultGameHeight);

            foreach (Ball b in mBalls)
            {
                b.onFrameRender();
            }

        }

        public void ConfigureFromXML (System.Xml.XmlNode pNode)
        {

            string value = pNode.Attributes["StartPosition"].Value;
            mPlayerInitialPosition = SMX.Maths.Vector2.ReadVector2FromString(value);
            //mPlayerInitialPosition = SMX.Maths.Vector2.ReadVector2FromXmlAttribute(pNode, "StartPosition");

            System.Xml.XmlNodeList ballNodes = pNode.SelectNodes("Ball");
            foreach (System.Xml.XmlNode ballNode in ballNodes)
            {

                Ball ball = new Ball();
                ball.ConfigureFromXML(ballNode);
                mBalls.Add(ball);

            }

        }
    }
}