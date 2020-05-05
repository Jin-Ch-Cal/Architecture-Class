using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(MeshFilter))]

public class SketchFace : MonoBehaviour
{
    Mesh mesh;

    public GameObject maincamera;

    Vector3[] cubeP;
    Vector3[] vertices;
    int[] triangles;

    public Vector3 click1;
    public Vector3 click2;
    Vector3 click3;
    Vector3 caculate0;
    Vector3 caculate3;

    public Vector3 h = new Vector3(0, 1, 0);

    int clickCount = 0;

    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;

        click1 = new Vector3(2f, 1f, 0);
        click2 = new Vector3(1.5f, 1f, 0);
        click3 = new Vector3(0, 0, 0);

        //Caculate caculate0 from click1 and click2 based on perpendicular rule.
        Vector3 delta12 = click2 - click1;
        caculate0 = (click1 + new Vector3(delta12.z, 0, -delta12.x)) / 2 + click2 / 2;
        caculate3 = (click1 + new Vector3(-delta12.z, 0, delta12.x)) / 2 + click2 / 2;
    }

    void Start()
    {
        
    }

    // Start is called before the first frame update
    void Update()
    {
        
        if(clickCount == 0)
        {
            click1 = ReadMouseClick(click1);
            
        }
        else if(clickCount == 1)
        {
            h.y = 0;
            click2 = ReadMouseMove();
            
            click2 = ReadMouseClick(click2);
        }else if (clickCount == 2) 
        {
            click3 = ReadMouseMoveHeight();
            
            click3 = ReadMouseClickHeight(click3);

            h.y = (click2 - click3).y;

        } else if (clickCount > 1)
        {
            clickCount = 0;
            
        }
        

        Caculate0and3();

        //Generating Mesh.
        MakeMeshData();
        CreateMesh();
    }

    Vector3 ReadMouseMoveHeight()
    {
        Vector3 sampleClick = -Vector3.one;

        //Raycast collides with an infinite plane which y = 1.
        Plane plane = new Plane(maincamera.transform.forward, click2);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distanceToPlane;

        if (plane.Raycast(ray, out distanceToPlane))
        {
            sampleClick = ray.GetPoint(distanceToPlane);
        }

        return sampleClick;
    }

    Vector3 ReadMouseClickHeight(Vector3 clickx)
    {
        //Input mouse click positions in world.
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 sampleClick = -Vector3.one;

            //Raycast collides with an infinite plane which .
            Plane plane = new Plane(maincamera.transform.forward, click2);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float distanceToPlane;

            if (plane.Raycast(ray, out distanceToPlane))
            {
                sampleClick = ray.GetPoint(distanceToPlane);
            }

            clickCount++;

            return sampleClick;
        }
        else
        {
            return clickx;
        }
    }

    Vector3 ReadMouseMove()
    {
        Vector3 sampleClick = -Vector3.one;

        //Raycast collides with an infinite plane which y = 1.
        Plane plane = new Plane(Vector3.up, -1f);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distanceToPlane;

        if (plane.Raycast(ray, out distanceToPlane))
        {
            sampleClick = ray.GetPoint(distanceToPlane);
        }

        return sampleClick;
    }

    Vector3 ReadMouseClick(Vector3 clickx)
    {
        //Input mouse click positions in world.
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 sampleClick = -Vector3.one;

            //Raycast collides with an infinite plane which y = 1.
            Plane plane = new Plane(Vector3.up, -1f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float distanceToPlane;

            if (plane.Raycast(ray, out distanceToPlane))
            {
                sampleClick = ray.GetPoint(distanceToPlane);
            }

            clickCount ++;

            return sampleClick;
        }
        else
        {
            return clickx;
        }
    }

    void Caculate0and3()
    {
        Vector3 delta12 = click2 - click1;
        caculate0 = (click1 + new Vector3(delta12.z, 0, -delta12.x)) / 2 + click2 / 2;
        caculate3 = (click1 + new Vector3(-delta12.z, 0, delta12.x)) / 2 + click2 / 2;
    }


    void MakeMeshData()
    {
 //     Vector3 y = new Vector3(0, YValue.ins.yValue, 0);

        //Create an array of eight cubePoints.
        cubeP = new Vector3[] { caculate0, click1, click2, caculate3, caculate0 - h, click1 - h, click2 - h, caculate3 - h };

        //Create an array of vertices.
        vertices = new Vector3[] {  cubeP[0],   cubeP[1],   cubeP[2],   cubeP[2],   cubeP[1],   cubeP[3],
                                    cubeP[0],   cubeP[2],   cubeP[6],   cubeP[0],   cubeP[6],   cubeP[4],
                                    cubeP[1],   cubeP[0],   cubeP[4],   cubeP[1],   cubeP[4],   cubeP[5],
                                    cubeP[3],   cubeP[1],   cubeP[5],   cubeP[3],   cubeP[5],   cubeP[7],
                                    cubeP[2],   cubeP[3],   cubeP[7],   cubeP[2],   cubeP[7],   cubeP[6],
                                    cubeP[4],   cubeP[6],   cubeP[5],   cubeP[5],   cubeP[6],   cubeP[7],  };

        //create an array of integers
        triangles = new int[] { 0, 1, 2, 3, 4, 5,
                                6, 7, 8, 9, 10, 11,
                                12, 13, 14, 15, 16, 17,
                                18, 19, 20, 21, 22, 23, 
                                24, 25, 26, 27, 28, 29};

    }

    void CreateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();  //Autoset normals as perpendicular.
    }
}
