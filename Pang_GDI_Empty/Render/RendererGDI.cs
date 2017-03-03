using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplePang 
{
    public class RendererGDI : RendererBase
    {
        public Dictionary<string, System.Drawing.Image> mTextures = new Dictionary<string, Image>();
        private System.Drawing.Graphics mGraphics;
        private Font mTextFont;


        /// <summary>
        /// 
        /// </summary>
        public RendererGDI()
        {
            mTextFont = new Font("Arial", 16, FontStyle.Bold);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pTextureName"></param>
        /// <param name="pStream"></param>
        public override void LoadTexture(string pTextureName, System.IO.Stream pStream)
        {
            if (mTextures.ContainsKey(pTextureName))
                return;

            System.Drawing.Image img = System.Drawing.Image.FromStream(pStream);
            mTextures.Add(pTextureName, img);
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
        public override void DrawSprite(string pTextureName, int pSrcX, int pSrcY, int pSrcWidth, int pSrcHeight, float pDestX, float pDestY, float pDestWidth, float pDestHeight)
        {
            mGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            mGraphics.DrawImage(mTextures[pTextureName], GetScreenCoords(pDestX, pDestY, pDestWidth, pDestHeight).ToGDI(), pSrcX, pSrcY, pSrcWidth, pSrcHeight, GraphicsUnit.Pixel);
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
        public override void DrawSprite(string pTextureName, float pDestX, float pDestY, float pDestWidth, float pDestHeight)
        {
            Image img = mTextures[pTextureName];
            mGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            mGraphics.DrawImage(img, GetScreenCoords(pDestX, pDestY, pDestWidth, pDestHeight).ToGDI(), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel);
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
        public override void DrawLine(float pX, float pY, float pDestX, float pDestY, float pWidth, bool pDashed, SMX.Maths.Color4 pColor)
        {
            Pen pen = new Pen(pColor.ToGDI(), pWidth);
            if (pDashed)
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            else pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

            Point start = GetScreenCoords(pX, pY, 1, 1).ToGDI().Location;
            Point end = GetScreenCoords(pDestX, pDestY, 1, 1).ToGDI().Location;
            mGraphics.DrawLine(pen, start, end);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pText"></param>
        /// <param name="pSize"></param>
        /// <param name="pX"></param>
        /// <param name="pY"></param>
        /// <param name="pColor"></param>
        public override void DrawText(string pText, int pSize, int pX, int pY, SMX.Maths.Color4 pColor)
        {
            System.Drawing.Font font = new Font("Arial", pSize, FontStyle.Bold);
            SolidBrush brush = new SolidBrush(pColor.ToGDI());

            SMX.Maths.Rectangle r = GetScreenCoords(pX, pY, 0, 0);
            mGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
            mGraphics.DrawString(pText, font, brush, new PointF(r.X, r.Y));
        }
      
    }
}
