using UnityEngine;
using System.Collections;

namespace Fardin.ColorTools
{
    public class ColorForm : MonoBehaviour
    {
        private Color rgb;

        private float alpha;
        private ColorHSB hsb;
        public string hexColor;
		 
		public Color RGB 
        {
            get { return rgb; }
			internal set
            {
				Debug.Log(""+value.r+", "+value.g+", "+value.b);
                IsChanged = true;
                rgb = value;
            }
        }
		public float Alpha
        {
            get { return alpha; }
			internal set
            {
                IsChanged = true;
                alpha = value;
            }
        }
		public ColorHSB HSB
        {
            get { return hsb; }
			internal set
            {
                IsChanged = true;
                hsb = value;
            }
        }
		public string HexColor
        {
            get { return hexColor; }
			internal set
            {
                IsChanged = true;
                hexColor = value;
            }
        }

        private bool isChanged;

        public bool IsChanged
        {
            get { return isChanged; }
            internal set { isChanged = value; }
        }


        internal void Initialize()
        {
            rgb = new Color();
            alpha = 1.0f;
            hsb = new ColorHSB();
            hexColor = "000000";
        }

        public void Initialize(Color rgb)
        {
            Initialize();
            RGB = rgb;
            HSB = ColorConverter.RGBToHSB(RGB);
            HexColor = ColorConverter.RGBToHex(RGB);
            alpha = rgb.a;
            IsChanged = true;
        }
    }
}