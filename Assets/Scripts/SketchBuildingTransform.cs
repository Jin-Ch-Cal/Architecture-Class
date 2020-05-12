using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(MeshFilter))]

public class SketchBuildingTransform : MonoBehaviour
{
    Mesh mesh;
    public GameObject sketchCube;
    public GameObject cityModelStill;
    public GameObject cityModelFollow;
    public GameObject enableComponentManager;
    private EnableComponent enableComponent;
    private SketchFace sketchFace;

    Vector3[] vertices;
    int[] triangles;
    Vector3[] buildingP;
    public Vector3 aZeroP = new Vector3 (0f, 0.52f, 0f);
    public Vector3 bZeroP = new Vector3 (6f, 0f, 72f);
    Vector3 playerDistance;


    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        sketchFace = sketchCube.GetComponent<SketchFace>();
        enableComponent = enableComponentManager.GetComponent<EnableComponent>();

        DecidePlayerDistance();
     }

    void Start()
    {
        
        MakeMeshData();
        CreateMesh();
    }

    // Update is called once per frame
    void Update()
    {
        DecidePlayerDistance();

        MakeMeshData();
        CreateMesh();
    }

    void DecidePlayerDistance()
    {
        if(enableComponent.show == true)
        {
            playerDistance = cityModelFollow.transform.position - cityModelStill.transform.position;

        }
        else
        {
            playerDistance = Vector3.zero;
        }
    }

    void MakeMeshData()
    {
        //     for(int i = 0; i <= 7; i++)
        //     {
        //         buildingP[i] = sketchFace.cubeP[i] * 2;
        //     }

        //Assign values to buidlingPs from cubePs.
        buildingP = new[] { ( sketchFace.cubeP[0] - aZeroP - playerDistance ) * 250 + bZeroP, 
                            ( sketchFace.cubeP[1] - aZeroP - playerDistance ) * 250 + bZeroP, 
                            ( sketchFace.cubeP[2] - aZeroP - playerDistance ) * 250 + bZeroP, 
                            ( sketchFace.cubeP[3] - aZeroP - playerDistance ) * 250 + bZeroP, 
                            ( sketchFace.cubeP[4] - aZeroP - playerDistance ) * 250 + bZeroP, 
                            ( sketchFace.cubeP[5] - aZeroP - playerDistance ) * 250 + bZeroP, 
                            ( sketchFace.cubeP[6] - aZeroP - playerDistance ) * 250 + bZeroP, 
                            ( sketchFace.cubeP[7] - aZeroP - playerDistance ) * 250 + bZeroP  };

        //Create an array of vertices.
        vertices = new Vector3[] {  buildingP[0],   buildingP[1],   buildingP[2],   buildingP[2],   buildingP[1],   buildingP[3],
                                    buildingP[0],   buildingP[6],   buildingP[2],   buildingP[0],   buildingP[4],   buildingP[6],
                                    buildingP[1],   buildingP[4],   buildingP[0],   buildingP[1],   buildingP[5],   buildingP[4],
                                    buildingP[3],   buildingP[5],   buildingP[1],   buildingP[3],   buildingP[7],   buildingP[5],
                                    buildingP[2],   buildingP[7],   buildingP[3],   buildingP[2],   buildingP[6],   buildingP[7],
                                    buildingP[4],   buildingP[5],   buildingP[6],   buildingP[5],   buildingP[7],   buildingP[6]  };

        //create an array of integers
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
