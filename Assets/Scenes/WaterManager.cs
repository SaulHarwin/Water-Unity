using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class WaterManager : MonoBehaviour {
    private MeshFilter meshFilter;

    private void Awake() {
        meshFilter = GetComponent<MeshFilter>();
    }

    public void Update() { 
        Vector3[] vertices = meshFilter.mesh.vertices;
        for (int i = 0; i < vertices.Length; i++) {
            vertices[i].y = WaveManager.instance.GetWaveY(transform.position.x + vertices[i].x);
            // vertices[i].x += WaveManager.instance.GetWaveX(transform.position.x + vertices[i].x);
        }

        meshFilter.mesh.vertices = vertices;
        meshFilter.mesh.RecalculateNormals();
    }
}
