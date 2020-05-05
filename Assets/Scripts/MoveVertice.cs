using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVertice : MonoBehaviour
{
    private SketchFace sketchFace;

    public Vector3 v4Move = new Vector3(0, 0, 0);
    public float moveSpeed = 10f;
    public float turnSpeed = 50f;

    bool selectedone = false;

    GameObject sphere4;

    void Awake()
    {
        sketchFace = GetComponent<SketchFace>();

        sphere4 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere4.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
    }

    void Update()
    {
        sphere4.transform.position = sketchFace.cubeP[4];


        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 200))
            {
                if ((hit.point - sketchFace.cubeP[4]).x < 1 && 
                    (hit.point - sketchFace.cubeP[4]).y < 1 && 
                    (hit.point - sketchFace.cubeP[4]).z < 1)
                {
                    Debug.Log("click!");

                    selectedone = !selectedone;
                }
                    
            }
        }
        


        
        
        ChangeMovement();
    }

    void ChangeMovement()
    {
        if (selectedone == true)
        {
            if (Input.GetKey(KeyCode.I))
                v4Move += Vector3.forward * moveSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.K))
                v4Move -= Vector3.forward * moveSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.J))
                v4Move += Vector3.left * moveSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.L))
                v4Move -= Vector3.left * moveSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.U))
                v4Move += Vector3.up * moveSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.M))
                v4Move -= Vector3.up * moveSpeed * Time.deltaTime;
        }
        
        
    }
    
}
