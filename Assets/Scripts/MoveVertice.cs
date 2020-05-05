using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVertice : MonoBehaviour
{
    public Vector3 vMove = new Vector3(0, 0, 0);

    public float moveSpeed = 10f;
    public float turnSpeed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
