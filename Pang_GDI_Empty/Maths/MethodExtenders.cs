using System;
using System.Collections.Generic;

namespace SMX.Maths
{
	/// <summary>
	/// Contains commonly used precalculated values and numeric calculations.
	/// </summary>
	public static class MethodExtenders
	{
		/// <summary>
		/// Represents the smallest positive <see cref="System.Single"/> greater than zero. This field is constant.
		/// </summary>
		public const float Epsilon = 1.0e-6f;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pValue"></param>
        /// <returns></returns>
        public static float FloatFromString(string pValue)
        {
            return float.Parse(pValue, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pValue"></param>
        /// <returns></returns>
        public static double DoubleFromString(string pValue)
        {
            return double.Parse(pValue, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="pSrc"></param>
        /// <returns></returns>
        public static Dictionary<T, V> Clone<T, V>(this Dictionary<T, V> pSrc)
        {
            Dictionary<T, V> ret = new Dictionary<T, V>();
            foreach (T key in pSrc.Keys)
                ret.Add(key, pSrc[key]);
            return ret;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pSrc"></param>
        /// <returns></returns>
        public static List<T> Clone<T>(this List<T> pSrc)
        {
            List<T> ret = new List<T>();
            foreach (T val in pSrc)
                ret.Add(val);

            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="pDoc"></param>
        /// <param name="pNd"></param>
        /// <param name="pAttName"></param>
        public static void ToXmlAttribute(this string a, System.Xml.XmlDocument pDoc, System.Xml.XmlNode pNd, string pAttName)
        {
            System.Xml.XmlAttribute att = pDoc.CreateAttribute(pAttName);

            // To Simax string
            att.Value = a;

            pNd.Attributes.Append(att);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="pDoc"></param>
        /// <param name="pNd"></param>
        /// <param name="pAttName"></param>
        public static void ToXmlAttribute(this float a, System.Xml.XmlDocument pDoc, System.Xml.XmlNode pNd, string pAttName)
        {
            System.Xml.XmlAttribute att = pDoc.CreateAttribute(pAttName);
            
            // To Simax string
            att.Value = a.ToString(System.Globalization.CultureInfo.InvariantCulture.NumberFormat);

            pNd.Attributes.Append(att);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="pDoc"></param>
        /// <param name="pNd"></param>
        /// <param name="pAttName"></param>
        public static void ToXmlAttribute(this double a, System.Xml.XmlDocument pDoc, System.Xml.XmlNode pNd, string pAttName)
        {
            System.Xml.XmlAttribute att = pDoc.CreateAttribute(pAttName);

            // To Simax string
            att.Value = a.ToString(System.Globalization.CultureInfo.InvariantCulture.NumberFormat);

            pNd.Attributes.Append(att);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="pDoc"></param>
        /// <param name="pNd"></param>
        /// <param name="pAttName"></param>
        public static void ToXmlAttribute(this bool a, System.Xml.XmlDocument pDoc, System.Xml.XmlNode pNd, string pAttName)
        {
            System.Xml.XmlAttribute att = pDoc.CreateAttribute(pAttName);

            // To Simax string
            att.Value = a.ToString();

            pNd.Attributes.Append(att);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="pDoc"></param>
        /// <param name="pNd"></param>
        /// <param name="pAttName"></param>
        public static void ToXmlAttribute(this int a, System.Xml.XmlDocument pDoc, System.Xml.XmlNode pNd, string pAttName)
        {
            System.Xml.XmlAttribute att = pDoc.CreateAttribute(pAttName);

            // To Simax string
            att.Value = a.ToString(System.Globalization.CultureInfo.InvariantCulture.NumberFormat);

            pNd.Attributes.Append(att);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pDoc"></param>
        /// <param name="pNode"></param>
        /// <param name="pVec"></param>
        public static void ToXmlAttribute(this System.Drawing.Color pCol, System.Xml.XmlDocument pDoc, System.Xml.XmlNode pNode, string pAttribNamePrefixToRGBA)
        {
            System.Xml.XmlAttribute att = pDoc.CreateAttribute(pAttribNamePrefixToRGBA + "R");
            att.InnerText = pCol.R.ToString();
            pNode.Attributes.Append(att);

            att = pDoc.CreateAttribute(pAttribNamePrefixToRGBA + "G");
            att.InnerText = pCol.G.ToString();
            pNode.Attributes.Append(att);

            att = pDoc.CreateAttribute(pAttribNamePrefixToRGBA + "B");
            att.InnerText = pCol.B.ToString();
            pNode.Attributes.Append(att);

            att = pDoc.CreateAttribute(pAttribNamePrefixToRGBA + "A");
            att.InnerText = pCol.A.ToString();
            pNode.Attributes.Append(att);
        }       
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static float FloatFromXmlAttribute(System.Xml.XmlNode pNode, string pAttName)
        {
            if (pNode.Attributes[pAttName] == null)
                throw new System.ApplicationException("Attribute: " + pAttName + " not found in node " + pNode.ToString());

            return FloatFromString(pNode.Attributes[pAttName].Value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int IntFromXmlAttribute(System.Xml.XmlNode pNode, string pAttName)
        {
            if (pNode.Attributes[pAttName] == null)
                throw new System.ApplicationException("Attribute: " + pAttName + " not found in node " + pNode.ToString());

            return int.Parse(pNode.Attributes[pAttName].Value, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
        }
    }
}
