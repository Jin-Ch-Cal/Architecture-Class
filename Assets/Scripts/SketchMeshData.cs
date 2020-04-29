using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SketchMeshData : MonoBehaviour
{
    /*
    int cliCount = 0;
    
    public Vector3[] vertices =
    {
        new Vector3( 1, 1, 1),
        new Vector3(-1, 1, 1),
        new Vector3(-1,-1, 1),
        new Vector3( 1,-1, 1),
        new Vector3(-1, 1,-1),
        new Vector3( 1, 1,-1),
        new Vector3( 1,-1,-1),
        new Vector3(-1,-1,-1),
    };


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

            cliCount ++;

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

    public  Vector3[] faceVertices(int dir)
    {
        Vector3[] fv = new Vector3[4];
        for (int i = 0; i < fv.Length; i++)
        {
            fv[i] = vertices[faceTriangles[dir][i]];
        }
        return fv;
    }
    */
}
