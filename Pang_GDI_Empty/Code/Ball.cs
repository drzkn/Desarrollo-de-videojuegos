using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePang
{
    public class Ball
    {

        public static string mTextureName = "";

        public enum eBallSize
        {
            XL,
            L,
            M,
            S
        }

        public enum eBallColor
        {
            Red,
            Blue,
            Green
        }

        public eBallColor mColor;
        public eBallSize mSize;
        public SMX.Maths.Vector2 mInitialPosition;
        public SMX.Maths.Rectangle mSpriteList = new SMX.Maths.Rectangle(1, 6, 48, 40);
        public SMX.Maths.Vector2 mVelocityPxS;

        public void OnFrameMove()
        {

            mVelocityPxS += Game.mGravityVel * Game.mDt;

            mInitialPosition += mVelocityPxS * Game.mDt;

            if(mInitialPosition.Y > Game.DefaultGameHeight - 256)
            {
                mVelocityPxS *= -1;
            }

            if (mInitialPosition.X > Game.DefaultGameWidth - 256)
            {
                mVelocityPxS *= -1;
            }

            /*if (mInitialPosition.Y > 256)
            {
                mVelocityPxS *= -1;
            }

            if (mInitialPosition.X > 256)
            {
                mVelocityPxS *= -1;
            }*/
            float maxHorizontalVelocity = 150f;
            if(maxHorizontalVelocity >= 0)
            {
                mVelocityPxS.X = maxHorizontalVelocity;
            }else
            {
                mVelocityPxS.X = -maxHorizontalVelocity;
            }
        }

        public void onFrameRender()
        {
            Game.mRenderer.DrawSprite(mTextureName, 
                mSpriteList.X, mSpriteList.Y, 
                mSpriteList.Width, mSpriteList.Height, 
                mInitialPosition.X,mInitialPosition.Y,256,256);

        }

        public void ConfigureFromXML (System.Xml.XmlNode pNode)
        {

            this.mInitialPosition = SMX.Maths.Vector2.ReadVector2FromString(pNode.Attributes["Position"].Value);
            this.mSize = (eBallSize)Enum.Parse(typeof(eBallSize), pNode.Attributes["Size"].Value);
            this.mColor = (eBallColor)Enum.Parse(typeof(eBallColor), pNode.Attributes["Type"].Value);

        }

    }

   
}
