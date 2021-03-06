﻿using System;
using UnityEngine;

namespace Samples
{
    public static class GameEnvironment
    {
        public static float GetDeltaTime()
        {
            return Time.deltaTime;
        }
    }

    public static class GameObjects
    {
        public static Vector3 GetCurrentPosition(MonoBehaviour behavior)
        {
            return behavior.GetComponent<Transform>().position;
        }

        public static void SetCurrentPosition(MonoBehaviour behavior, Vector3 position)
        {
            behavior.GetComponent<Transform>().position = position;
        }
    }

    public static class Textures
    {
        public static Texture2D CreateTexture(Color color)
        {
            int width = 100;
            int height = 100;

            var texture = new Texture2D(width, height, TextureFormat.ARGB32, false);
            texture.filterMode = FilterMode.Point;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    texture.SetPixel(j, height - 1 - i, color);
                }
            }
            texture.Apply();
            return texture;
        }

        public static void SetMainTextureOnMaterial(Component component, Texture2D texture)
        {
            component.GetComponent<Renderer>().material.mainTexture = texture;
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

    public static class Meshes
    {
        public static void AddMeshRenderingComponents(GameObject gObject)
        {
            gObject.AddComponent<MeshFilter>();
            gObject.AddComponent<MeshRenderer>();
        }

        public static Mesh CreateSimpleMesh()
        {
            var mesh = new Mesh();

            mesh.vertices = new Vector3[] { new Vector3(0, 0, 0), new Vector3(0, 1, 0), new Vector3(1, 1, 0) };
            mesh.uv = new Vector2[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1) };
            mesh.triangles = new int[] { 0, 1, 2 };

            return mesh;
        }

        public static void SetCurrentMesh(MonoBehaviour behavior, Mesh mesh)
        {
            var meshFilter = behavior.GetComponent<MeshFilter>();
            meshFilter.mesh = mesh;
        }

        public static void DrawMesh(Mesh mesh, Material material, float x, float y, float z)
        {
            Graphics.DrawMesh(mesh, new Vector3(x, y, z), Quaternion.identity, material, 0);
        }
    }

    public static class Materials
    {
        public static Material CreateSimpleMaterial(Component component)
        {
            var material = new Material(Shader.Find("Transparent/Diffuse"));
            material.color = Color.green;
            return material;
        }
    }
}

