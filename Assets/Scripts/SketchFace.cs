using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter))]

public class SketchFace : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    Vector3 click1;
    Vector3 click2;
    Vector3 caculate0;

    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;

        click1 = new Vector3(0, 0, 1);
        click2 = new Vector3(1, 0, 2);
        
        //cacalating caculate0 from click1 and click2 based on perpendicular rule.
        Vector3 delta12 = click2 - click1;
        caculate0 = (click1 + new Vector3(delta12.z, 0, -delta12.x)) / 2 + click2 / 2;
    }

    void Start()
    {
        Debug.Log(click1.ToString());
        Debug.Log(caculate0.ToString());
    }

    // Start is called before the first frame update
    void Update()
    {
        MakeMeshData();
        CreateMesh();
    }

    void MakeMeshData()
    {
        //Create an array of vertices
        vertices = new Vector3[] { caculate0, click1, click2 };

        //create an array of integers
        triangles = new int[] { 0, 1, 2 };

    }

    void CreateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();  //Autoset normals as perpendicular.
    }
}
