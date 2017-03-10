using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePang
{
    public class RendererBase
    {       
        protected float mScaleX, mScaleY;
        protected float mOffsetX, mOffsetY;
        public int mGameWidth, mGameHeight;
        public int mScreenWidth, mScreenHeight;

        /// <summary>
        /// Loads a texture
        /// </summary>
        /// <param name="pTextureName"></param>
        /// <param name="pStream"></param>
        public virtual void LoadTexture(string pTextureName, System.IO.Stream pStream)
        {
        }

        public virtual void LoadTexture(string pTextureName)
        {
            System.IO.FileStream stream = new System.IO.FileStream(pTextureName, System.IO.FileMode.Open);
            LoadTexture(pTextureName, stream);
            stream.Dispose();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pGameWidth"></param>
        /// <param name="pGameHeight"></param>
        /// <param name="pScreenWidth"></param>
        /// <param name="pScreenHeight"></param>
        public void SetGameWindow(int pGameWidth, int pGameHeight, int pScreenWidth, int pScreenHeight)
        {
            mGameWidth = pGameWidth;
            mGameHeight = pGameHeight;
            mScreenWidth = pScreenWidth;
            mScreenHeight = pScreenHeight;

            SMX.Maths.Rectangle dR = CalcZoomRectangle(this.mScreenWidth, this.mScreenHeight, mGameWidth, mGameHeight);
            mOffsetX = dR.X;
            mOffsetY = dR.Y;
            mScaleX = (float)dR.Width / (float)mGameWidth;
            mScaleY = (float)dR.Height / (float)mGameHeight;
        }
        /// <summary>
        /// Este método es una copia del propio código del PictureBox, mirado en el codigo fuente de .Net
        /// </summary>
        /// <param name="pContainerClientRectangleWidth"></param>
        /// <param name="pContainerClientRectangleHeight"></param>
        /// <param name="pImageWidth"></param>
        /// <param name="pImageHeight"></param>
        /// <returns></returns>
        public static SMX.Maths.Rectangle CalcZoomRectangle(int pContainerClientRectangleWidth, int pContainerClientRectangleHeight, int pImageWidth, int pImageHeight)
        {
            SMX.Maths.Rectangle ret = new SMX.Maths.Rectangle();

            float ratio = Math.Min((float)pContainerClientRectangleWidth / (float)pImageWidth, (float)pContainerClientRectangleHeight / (float)pImageHeight);
            ret.Width = (int)(pImageWidth * ratio);
            ret.Height = (int)(pImageHeight * ratio);
            ret.X = (pContainerClientRectangleWidth - ret.Width) / 2;
            ret.Y = (pContainerClientRectangleHeight - ret.Height) / 2;
            return ret;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pX"></param>
        /// <param name="pY"></param>
        /// <param name="pWidth"></param>
        /// <param name="pHeight"></param>
        /// <returns></returns>
        public SMX.Maths.Rectangle GetScreenCoords(int pX, int pY, int pWidth, int pHeight)
        {
            return new SMX.Maths.Rectangle((int)(((float)pX * mScaleX) + mOffsetX), (int)(((float)pY * mScaleY) + mOffsetY), (int)((float)pWidth * mScaleX), (int)((float)pHeight * mScaleY));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pX"></param>
        /// <param name="pY"></param>
        /// <param name="pWidth"></param>
        /// <param name="pHeight"></param>
        /// <returns></returns>
        public SMX.Maths.Rectangle GetScreenCoords(float pX, float pY, float pWidth, float pHeight)
        {
            return new SMX.Maths.Rectangle((int)((pX * mScaleX) + mOffsetX), (int)((pY * mScaleY) + mOffsetY), (int)(pWidth * mScaleX), (int)(pHeight * mScaleY));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pTextureName"></param>
        /// <param name="pSrcX"></param>
        /// <param name="pSrcY"></param>
        /// <param name="pSrcWidth"></param>
        /// <param name="pSrcHeight"></param>
        /// <param name="pDestX"></param>
        /// <param name="pDestY"></param>
        /// <param name="pDestWidth"></param>
        /// <param name="pDestHeight"></param>
        public virtual void DrawSprite(string pTextureName, int pSrcX, int pSrcY, int pSrcWidth, int pSrcHeight, float pDestX, float pDestY, float pDestWidth, float pDestHeight)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pTextureName"></param>
        /// <param name="pSrcX"></param>
        /// <param name="pSrcY"></param>
        /// <param name="pSrcWidth"></param>
        /// <param name="pSrcHeight"></param>
        /// <param name="pDestX"></param>
        /// <param name="pDestY"></param>
        /// <param name="pDestWidth"></param>
        /// <param name="pDestHeight"></param>
        public virtual void DrawSprite(string pTextureName, float pDestX, float pDestY, float pDestWidth, float pDestHeight)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pX"></param>
        /// <param name="pY"></param>
        /// <param name="pDestX"></param>
        /// <param name="pDestY"></param>
        /// <param name="pWidth"></param>
        /// <param name="pDashed"></param>
        /// <param name="pColor"></param>
        public virtual void DrawLine(float pX, float pY, float pDestX, float pDestY, float pWidth, bool pDashed, SMX.Maths.Color4 pColor)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pText"></param>
        /// <param name="pSize"></param>
        /// <param name="pX"></param>
        /// <param name="pY"></param>
        /// <param name="pColor"></param>
        public virtual void DrawText(string pText, int pSize, int pX, int pY, SMX.Maths.Color4 pColor)
        {
        }
    }
}
