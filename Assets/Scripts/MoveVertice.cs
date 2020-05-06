using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVertice : MonoBehaviour
{
    private SketchFace sketchFace;

    public Vector3 vMove4;
    public Vector3 vMove5;
    public Vector3 vMove6;
    public Vector3 vMove7;


    public float moveSpeed = 10f;
    public float turnSpeed = 50f;

    int selectedone = 0;

    GameObject sphere4;
    GameObject sphere5;
    GameObject sphere6;
    GameObject sphere7;

    void Awake()
    {
        sketchFace = GetComponent<SketchFace>();

        sphere4 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere4.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
        sphere5 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere5.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
        sphere6 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere6.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
        sphere7 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere7.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
    }

    void Update()
    {
        sphere4.transform.position = sketchFace.cubeP[4];
        sphere5.transform.position = sketchFace.cubeP[5];
        sphere6.transform.position = sketchFace.cubeP[6];
        sphere7.transform.position = sketchFace.cubeP[7];

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 200))
            {
                if ((hit.point - sketchFace.cubeP[4]).x < 0.1 &&
                    (hit.point - sketchFace.cubeP[4]).y < 0.1 &&
                    (hit.point - sketchFace.cubeP[4]).z < 0.1)
                {
                    Debug.Log("click4!");

                    selectedone = 4;
                }
                else if ((hit.point - sketchFace.cubeP[5]).x < 0.1 &&
                   (hit.point - sketchFace.cubeP[5]).y < 0.1 &&
                   (hit.point - sketchFace.cubeP[5]).z < 0.1)
                {
                    Debug.Log("click5!");

                    selectedone = 5;
                }
                else if ((hit.point - sketchFace.cubeP[6]).x < 0.1 &&
                   (hit.point - sketchFace.cubeP[6]).y < 0.1 &&
                   (hit.point - sketchFace.cubeP[6]).z < 0.1)
                {
                    Debug.Log("click6!");

                    selectedone = 6;
                }
                else if ((hit.point - sketchFace.cubeP[7]).x < 0.1 &&
                  (hit.point - sketchFace.cubeP[7]).y < 0.1 &&
                  (hit.point - sketchFace.cubeP[7]).z < 0.1)
                {
                    Debug.Log("click7!");

                    selectedone = 7;

                }
            }

         }

            ChangeMovement();
        }

    void ChangeMovement()
    {
        if (selectedone == 4)
        {
            vMove4 = ChangeSpecificPoint(vMove4);
        }
        else if (selectedone == 5)
        {
            vMove5 = ChangeSpecificPoint(vMove5);
        }
        else if (selectedone == 6)
        {
            vMove6 = ChangeSpecificPoint(vMove6);
        }
        else if (selectedone == 7)
        {
            vMove7 = ChangeSpecificPoint(vMove7);
        }

    }

    Vector3 ChangeSpecificPoint(Vector3 viMove)
    {
        if (Input.GetKey(KeyCode.I))
            viMove += Vector3.forward * moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.K))
            viMove -= Vector3.forward * moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.J))
            viMove += Vector3.left * moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.L))
            viMove -= Vector3.left * moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.U))
            viMove += Vector3.up * moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.M))
            viMove -= Vector3.up * moveSpeed * Time.deltaTime;

        return viMove;
    }
    
}
