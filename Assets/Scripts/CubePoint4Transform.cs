using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePoint4Transform : MonoBehaviour
{
    public GameObject sketchCube;
    private SketchFace sketchFace;

    private void Awake()
    {
        sketchFace = sketchCube.GetComponent<SketchFace>();
    }

    
    void Update()
    {
        transform.position = sketchFace.cubeP[4];
    }
}
