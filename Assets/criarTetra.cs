using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class criarTetra : MonoBehaviour {


    public bool sharedVertices = false;

    Vector3 p0 = new Vector3(0, 0, 0);
    Vector3 p1 = new Vector3(1, 0, 0);
    Vector3 p2 = new Vector3(0.5f, 0, Mathf.Sqrt(0.75f)); // o ponto de trás
    Vector3 p3 = new Vector3(0.5f, Mathf.Sqrt(0.75f), Mathf.Sqrt(0.75f) / 3); // o ponto de cima
    Vector3 c;
    Mesh mesh;

    public Vector3[] getVectors()
    {

        Vector3[] vertex = new Vector3[] { p0, p1, p2, p3 };
        return vertex;

    }

    public Vector3 getCenter()
    {
        c = (p0 + p1 + p2 + p3) / 4f;
        return c;
    }

    public void Rebuild()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter == null)
        {
            Debug.LogError("MeshFilter not found!");
            return;
        }

        // centro do tetraedro
        // Vector3 c = (p0 + p1 + p2 + p3) / 4f;
        //transform.position = c; // na hora do 'for' do manager, essa linha sobrescreve os Instatiate, logo, todos os tetras sao gerados na posicao de c.

        // centraliza os pontos
        // Vector3 v0 = p0 - c;
        // Vector3 v1 = p1 - c;
        // Vector3 v2 = p2 - c;
        // Vector3 v3 = p3 - c;


        mesh = meshFilter.sharedMesh;
        if (mesh == null)
        {
            meshFilter.mesh = new Mesh();
            mesh = meshFilter.sharedMesh;
        }
        mesh.Clear();

        mesh.vertices = new Vector3[]{
           p0,p1,p2,
           p0,p2,p3,
           p2,p1,p3,
           p0,p3,p1
        };

        // mesh.vertices = new Vector3[]{
        //     v0,v1,v2,
        //     v0,v2,v3,
        //     v2,v1,v3,
        //     v0,v3,v1
        //  };

        mesh.triangles = new int[]
        {
            0,1,2,
            3,4,5,
            6,7,8,
            9,10,11
        };

        Color[] color = new Color[mesh.vertices.Length]; // 12 vetores
        color[0] = Color.blue;
        color[1] = Color.blue;
        color[2] = Color.blue;

        color[3] = Color.red;
        color[4] = Color.red;
        color[5] = Color.red;

        color[6] = Color.yellow;
        color[7] = Color.yellow;
        color[8] = Color.yellow;

        color[9] = Color.green;
        color[10] = Color.green;
        color[11] = Color.green;

        mesh.colors = color;

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        //mesh.Optimize();
    }

    // Use this for initialization
    void Start () {
        Rebuild();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
