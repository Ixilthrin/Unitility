using UnityEngine;
using System.Collections;

public class UseGraphics : MonoBehaviour {

    // Use this for initialization
    void Start () { } 
    // Update is called once per frame
    void Update () { }

    void OnPostRender()
    {
        GL.PushMatrix();
        GL.LoadOrtho();
        GL.Begin(GL.LINES);
        GL.Color(Color.red);
        GL.Vertex3(0, 0, 0);
        GL.Vertex3(50, 50, 0);
        GL.End();
        GL.PopMatrix();
    }
}
