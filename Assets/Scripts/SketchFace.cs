using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(MeshFilter))]

public class SketchFace : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    Vector3 click1;
    Vector3 click2;
    Vector3 caculate0;
    Vector3 caculate3;

    Vector3 h = new Vector3(0, 1, 0);

    int clickCount = 0;

    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;

        click1 = new Vector3(0, 0, 1);
        click2 = new Vector3(0, 0, 0);
        
        //Caculate caculate0 from click1 and click2 based on perpendicular rule.
        Vector3 delta12 = click2 - click1;
        caculate0 = (click1 + new Vector3(delta12.z, 0, -delta12.x)) / 2 + click2 / 2;
        caculate3 = (click1 + new Vector3(-delta12.z, 0, delta12.x)) / 2 + click2 / 2;
    }

    void Start()
    {
        //Just for testing. Temporary.
 //     Debug.Log("click1:" + click1.ToString()); 
 //     Debug.Log("click2:" + click2.ToString());
 //     Debug.Log("caculate0" + caculate0.ToString());
 //     Debug.Log("caculate3" + caculate3.ToString());
    }

    // Start is called before the first frame update
    void Update()
    {
        
        
        if(clickCount == 0)
        {
            click1 = ReadMouseClick(click1);
        }else if(clickCount == 1)
        {
            click2 = ReadMouseClick(click2);
        }else if(clickCount > 1)
        {
            clickCount = 0;
        }
        

        Caculate0and3();

        //Generating Mesh.
        MakeMeshData();
        CreateMesh();
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

            clickCount ++;

            Debug.Log(sampleClick);
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
        caculate3 = (click1 + new Vector3(-delta12.z, YValue.ins.yValue, delta12.x)) / 2 + click2 / 2;
    }


    void MakeMeshData()
    {
        Vector3 y = new Vector3(0, YValue.ins.yValue, 0)/2;
        
        //Create an array of vertices
        vertices = new Vector3[] {  caculate0,      click1,     click2,              click2,         click1,            caculate3,
                                    caculate0,      click2,     click2 - h,          caculate0,      click2 - h,        caculate0 - h,
                                    click1,      caculate0,     caculate0 - h,       click1,         caculate0 - h,     click1 - h,
                                    caculate3,      click1,     click1 - h,          caculate3,         click1 - h,         caculate3 - h - y,
                                    click2,      caculate3,     caculate3 - h - y,       click2,          caculate3 - h - y,        click2 - h,};

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
