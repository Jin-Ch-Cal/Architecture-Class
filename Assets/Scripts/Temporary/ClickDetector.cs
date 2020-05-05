using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickDetector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 sampleClick = -Vector3.one;

            //Raycast using colliders.
            //This method is dumped because of Unity version difference.
 //         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
 //         RaycastResult hit;
 //         if (Physics.Raycast(ray, out hit))
 //         {
 //             sampleClick = hit.point;
 //         }
            
            //Raycast collides with an infinite plane which y = 0.
            Plane plane = new Plane(Vector3.up, 0f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float distanceToPlane;

            if (plane.Raycast(ray, out distanceToPlane))
            {
                sampleClick = ray.GetPoint(distanceToPlane);
            }


            //Log click position in world space ot the console.
            Debug.Log(sampleClick);

        }
        
    }
}
