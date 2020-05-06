using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]

public class SketchBuildingTransform : MonoBehaviour
{
    Mesh mesh;
    public GameObject sketchCube;
    private SketchFace sketchFace;

    Vector3[] vertices;
    int[] triangles;
    Vector3[] buildingP = new Vector3[8];
    Vector3 deltaPosition;
    Vector3 bInitialPostion;

    void Start()
    {
        sketchFace = sketchCube.GetComponent<SketchFace>();
        
        bInitialPostion = transform.position;
        deltaPosition = transform.position - sketchCube.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MakeMeshData();
        CreateMesh();
    }

    void MakeMeshData()
    {
//      for(int i = 0; i <= 7; i++)
//      {
//          buildingP[i] = bInitialPostion + sketchFace.cubeP[i] * 250;
//      }

        buildingP[1] = sketchFace.cubeP[1] * 250;


        vertices = new Vector3[] {  buildingP[0],   buildingP[1],   buildingP[2],   buildingP[2],   buildingP[1],   buildingP[3],
                                    buildingP[0],   buildingP[6],   buildingP[2],   buildingP[0],   buildingP[4],   buildingP[6],
                                    buildingP[1],   buildingP[4],   buildingP[0],   buildingP[1],   buildingP[5],   buildingP[4],
                                    buildingP[3],   buildingP[5],   buildingP[1],   buildingP[3],   buildingP[7],   buildingP[5],
                                    buildingP[2],   buildingP[7],   buildingP[3],   buildingP[2],   buildingP[6],   buildingP[7],
                                    buildingP[4],   buildingP[5],   buildingP[6],   buildingP[5],   buildingP[7],   buildingP[6],  };
    }

    void CreateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();  //Autoset normals as perpendicular.
    }
}
