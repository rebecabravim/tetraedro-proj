using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class criarTriangulo : MonoBehaviour {


    public bool sharedVertices = false;

    Vector3 p0 = new Vector3(0, 0, 0);
    Vector3 p1 = new Vector3(2, 0, 0);
    Vector3 p2 = new Vector3(1, 2, 0);
    Mesh mesh;

    public Vector3[] getVectors()
    {
        Vector3[] vertex = new Vector3[] { p0, p1, p2 };
        return vertex;

    }

    public void Rebuild()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter == null)
        {
            Debug.LogError("MeshFilter not found!");
            return;
        }

        mesh = meshFilter.sharedMesh;
        if (mesh == null)
        {
            meshFilter.mesh = new Mesh();
            mesh = meshFilter.sharedMesh;
        }
        mesh.Clear();

        mesh.vertices = getVectors();
        mesh.triangles = new int[3] {0,1,2};

        Color[] color = new Color[mesh.vertices.Length]; // 3 vetores
        color[0] = Color.blue;
        color[1] = Color.blue;
        color[2] = Color.blue;

        mesh.colors = color;

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }

    // Use this for initialization
    void Start () {
        Rebuild();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
