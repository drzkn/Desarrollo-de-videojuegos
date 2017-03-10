using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePang
{
    public class Player
    {

        public string mTextureName = "";
    
        public void onFrameMove()
        {
            
        }
        public void onFrameRender()
        {
            Game.mRenderer.DrawSprite(mTextureName, 10, 0, 33, 35, 900, 912, 128, 128);
        }
    }

}
