using System;
using UnityEngine;

namespace Samples
{
    public static class Textures
    {
        public static Texture2D CreateTexture(Color color)
        {
            int width = 100;
            int height = 100;

            var texture = new Texture2D(width, height, TextureFormat.ARGB32, false);
            texture.filterMode = FilterMode.Point;

            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height; j++) {
                    texture.SetPixel(j, height - 1 - i, color);
                }
            }
            texture.Apply();
            return texture;
        }

        public static void SetMainTextureOnMaterial(MonoBehaviour behavior, Texture2D texture)
        {
            behavior.GetComponent<Renderer>().material.mainTexture = texture;
        }
    }

    public static class Colors
    {
        public static Color GetGreenColor()
        {
            return Color.green;
        }

        public static Color GetColorByRGBValue(float red, float green, float blue)
        {
            return new Color(red, green, blue);
        }
    }
}
	
