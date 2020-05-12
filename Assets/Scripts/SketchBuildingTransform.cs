using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(MeshFilter))]

public class SketchBuildingTransform : MonoBehaviour
{
    Mesh mesh;
    public GameObject sketchCube;
    private SketchFace sketchFace;

    Vector3[] vertices;
    int[] triangles;
    Vector3[] buildingP;
    Vector3 deltaPosition;
    Vector3 bInitialPostion;

    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        sketchFace = sketchCube.GetComponent<SketchFace>();

        bInitialPostion = transform.position;
        deltaPosition = transform.position - sketchCube.transform.position;

 //     for(int i = 0; i <= 7; i++)
 //     {
 //         buildingP[i] = new Vector3(0, 0, 0);
 //     }
    }

    void Start()
    {
        MakeMeshData();
        CreateMesh();
    }

    // Update is called once per frame
    void Update()
    {
        MakeMeshData();
        CreateMesh();

        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("0: " + buildingP[0] + sketchFace.cubeP[0]);
            Debug.Log("1: " + buildingP[1] + sketchFace.cubeP[1]);
            Debug.Log("2: " + buildingP[2] + sketchFace.cubeP[2]);
        }
    }

    void MakeMeshData()
    {
        //     for(int i = 0; i <= 7; i++)
        //     {
        //         buildingP[i] = sketchFace.cubeP[i] * 2;
        //     }

        buildingP = new[] { sketchFace.cubeP[0] * 2, 
                            sketchFace.cubeP[1] * 2, 
                            sketchFace.cubeP[2] * 2, 
                            sketchFace.cubeP[3] * 2, 
                            sketchFace.cubeP[4] * 2, 
                            sketchFace.cubeP[5] * 2, 
                            sketchFace.cubeP[6] * 2, 
                            sketchFace.cubeP[7] * 2  };

        //     buildingP[1] = sketchFace.cubeP[1] * 2;

        
        vertices = new Vector3[] {  buildingP[0],   buildingP[1],   buildingP[2],   buildingP[2],   buildingP[1],   buildingP[3],
                                    buildingP[0],   buildingP[6],   buildingP[2],   buildingP[0],   buildingP[4],   buildingP[6],
                                    buildingP[1],   buildingP[4],   buildingP[0],   buildingP[1],   buildingP[5],   buildingP[4],
                                    buildingP[3],   buildingP[5],   buildingP[1],   buildingP[3],   buildingP[7],   buildingP[5],
                                    buildingP[2],   buildingP[7],   buildingP[3],   buildingP[2],   buildingP[6],   buildingP[7],
                                    buildingP[4],   buildingP[5],   buildingP[6],   buildingP[5],   buildingP[7],   buildingP[6]  };

        triangles = new int[] { 0, 1, 2, 3, 4, 5,
                                6, 7, 8, 9, 10, 11,
                                12, 13, 14, 15, 16, 17,
                                18, 19, 20, 21, 22, 23,
                                24, 25, 26, 27, 28, 29,
                                30, 31, 32, 33, 34, 35 }; 

 //     vertices = new Vector3[] { new Vector3(0, 0, 0), new Vector3(0, 0, 1), new Vector3(1, 0, 0) };
 //     triangles = new int[] { 0, 1, 2 };
    }

    void CreateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();  //Autoset normals as perpendicular.
    }
}
