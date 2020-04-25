using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelMovement : MonoBehaviour
{
    public float modelmoveSpeed = 10f;
    public float modelturnSpeed = 50f;
    Vector3 scaleChange;

    void Awake()
    {
        scaleChange = new Vector3(0.01f, 0.01f, 0.01f);
    }

    void Start()
    {
        
    }

    void Update()
    {
        //Move model forward, back, left, and right, by keyboard.
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.forward * modelmoveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(-Vector3.forward * modelmoveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(Vector3.left * modelmoveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(Vector3.right * modelmoveSpeed * Time.deltaTime);

        //Rotate model by mouse wheel.
        transform.Rotate(Vector3.up, Input.mouseScrollDelta.y * modelturnSpeed);

        //Scale model by [ and ].
        if (Input.GetKey(KeyCode.RightBracket))
            transform.localScale += scaleChange;
        if (Input.GetKey(KeyCode.LeftBracket))
            transform.localScale -= scaleChange;


    }
}
