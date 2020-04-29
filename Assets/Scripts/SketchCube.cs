using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class SketchCube : MonoBehaviour
{
    Mesh mesh;
    List<Vector3> vertices;
    List<int> triangles;

    int cliCount = 0;

    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    void Start()
    {
        MakeCube();
        UpdateMesh();
    }

    void MakeCube()
    {
        vertices = new List<Vector3>();
        triangles = new List<int>();

        for (int i = 0; i < 6; i++)
        {
            MakeFace(i);
        }
    }

    void MakeFace(int dir)
    {
        vertices.AddRange(faceVertices(dir));
        int vCount = vertices.Count;

        triangles.Add(vCount - 4);
        triangles.Add(vCount - 4 + 1);
        triangles.Add(vCount - 4 + 2);
        triangles.Add(vCount - 4 + 0);
        triangles.Add(vCount - 4 + 2);
        triangles.Add(vCount - 4 + 3);
    }

    void UpdateMesh()
    {
        points[0] = ReadMouseClick(points[0]);

        Debug.Log("point0:" + points[0]);

        mesh.Clear();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();

        mesh.RecalculateNormals();  //Autoset normals as perpendicular.x
    }



    //GOAL: points data.

        
    public Vector3[] points =
    {
        new Vector3( 1, 2, 1),
        new Vector3(-1, 1, 1),
        new Vector3(-1,-1, 1),
        new Vector3( 1,-1, 1),
        new Vector3(-1, 1,-1),
        new Vector3( 1, 1,-1),
        new Vector3( 1,-1,-1),
        new Vector3(-1,-1,-1),
    };

    //GOAL: switch data.
    private void Update()
    {
        
    }



    private Vector3 ReadMouseClick(Vector3 clickx)
    {
        //Input mouse click positions in world.
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 sampleClick = -Vector3.one;

            //Raycast collides with an infinite plane which y = 0.
            Plane plane = new Plane(Vector3.up, 0f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float distanceToPlane;

            if (plane.Raycast(ray, out distanceToPlane))
            {
                sampleClick = ray.GetPoint(distanceToPlane);
            }

            cliCount++;

            Debug.Log(sampleClick);
            return sampleClick;
        }
        else
        {
            return clickx;
        }
    }

    public int[][] faceTriangles =
    {
        new int[] {0, 1, 2, 3},
        new int[] {5, 0, 3, 6},
        new int[] {4, 5, 6, 7},
        new int[] {1, 4, 7, 2},
        new int[] {5, 4, 1, 0},
        new int[] {3, 2, 7, 6},
    };

    public Vector3[] faceVertices(int dir)
    {
        Vector3[] fv = new Vector3[4];
        for (int i = 0; i < fv.Length; i++)
        {
            fv[i] = points[faceTriangles[dir][i]];
        }
        return fv;
    }

}
