using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SampleProceduralCube : MonoBehaviour {
    int size = 1;

    void cube()
    {
        var vertices = new Vector3[] 
        {
            new Vector3(size, size, size),
            new Vector3(-size, size, size),
            new Vector3(-size, -size, size),
            new Vector3(size, -size, size),
            new Vector3(size, size, -size),
            new Vector3(-size, size, -size),
            new Vector3(-size, -size, -size),
            new Vector3(size, -size, -size),
        };

        var triangles = new int[] 
        {
            0, 1, 2,
            0, 2, 3,
            4, 0, 3,
            4, 3, 7,
            5, 4, 7,
            5, 7, 6,
            1, 5, 6,
            1, 6, 2,
            4, 5, 1,
            4, 1, 0,
            3, 2, 7,
            3, 6, 7
        };

        var mesh = new Mesh();
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        (GetComponent<MeshFilter>()).mesh = mesh;
    }
    
    void Start ()
    {
        gameObject.AddComponent<MeshRenderer>();
        gameObject.AddComponent<MeshFilter>();
        cube();
    }
	
	void Update ()
    {
	}
}
