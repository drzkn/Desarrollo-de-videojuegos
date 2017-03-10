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

        public void onFrameMove()
        {

        }

        public void onFrameRender()
        {

            Game.mRenderer.DrawSprite(mBackgroundTextureName,0,0,Game.DefaultGameWidth,Game.DefaultGameHeight);

        }
    }
}