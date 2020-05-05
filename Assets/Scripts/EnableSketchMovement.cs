using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableSketchMovement : MonoBehaviour
{
    public GameObject sketchCube;
    private SketchMovement sketchMovement;


    void Start()
    {
        sketchMovement = sketchCube.GetComponent<SketchMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            sketchMovement.enabled = !sketchMovement.enabled;
        }
    }
}
