using UnityEngine;
using System.Collections;
using Samples;
using System;

public class SampleProceduralMesh : MonoBehaviour
{
    public float xDirection;
    public float _velocity;

    public void Start()
    {
        Meshes.AddMeshRenderingComponents(gameObject);

        _velocity = 5f;
        xDirection = 1f;

        var mesh = Meshes.CreateSimpleMesh();
        Meshes.SetCurrentMesh(this, mesh);
    }

    public void Update()
    {
        float distanceTraveled = GameEnvironment.GetDeltaTime() * _velocity;

        var position = GameObjects.GetCurrentPosition(this);
        position.x += distanceTraveled * xDirection;

        if (position.x > 10)
            xDirection = -1f;
        if (position.x < 0)
            xDirection = 1f;

        GameObjects.SetCurrentPosition(this, position);
    }
}
