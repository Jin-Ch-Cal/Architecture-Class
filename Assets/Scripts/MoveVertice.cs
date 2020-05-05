using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVertice : MonoBehaviour
{
    private SketchFace sketchFace;

    public Vector3 vMove = new Vector3(0, 0, 0);
    public float moveSpeed = 10f;
    public float turnSpeed = 50f;

    GameObject sphere4;

    // Start is called before the first frame update
    void Awake()
    {
        sketchFace = GetComponent<SketchFace>();
        sphere4 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere4.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
    }

    // Update is called once per frame
    void Update()
    {
        sphere4.transform.position = sketchFace.cubeP[4] + vMove;

        if (Input.GetKey(KeyCode.I))
            vMove += Vector3.forward * moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.K))
            vMove -= Vector3.forward * moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.J))
            vMove += Vector3.left * moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.L))
            vMove -= Vector3.left * moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.U))
            vMove += Vector3.up * moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.M))
            vMove -= Vector3.up * moveSpeed * Time.deltaTime;
    }

    
}
