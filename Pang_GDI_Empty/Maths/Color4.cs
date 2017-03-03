using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Globalization;
using System.Drawing;

namespace SMX.Maths
{
    public struct Color4
    {
        public float Red;
        public float Green;
        public float Blue;
        public float Alpha;

        public static Color4 White
        {
            get
            {
                return new Color4(uint.MaxValue);
            }
        }
        public static Color4 Zero
        {
            get { return new Color4(0); }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="argb"></param>
        public Color4(uint argb)
        {
            this.Alpha = (float)(((double)((argb >> 0x18) & 0xff)) / 255.0);
            this.Blue = (float)(((double)((argb >> 0x10) & 0xff)) / 255.0);
            this.Green = (float)(((double)((argb >> 8) & 0xff)) / 255.0);
            this.Red = (float)(((double)(argb & 0xff)) / 255.0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Color ToGDI()
        {
            return Color.FromArgb((int)(this.Alpha * 255.0), (int)(this.Red * 255.0), (int)(this.Green * 255.0), (int)(this.Blue * 255.0));
        }    
    }
}

