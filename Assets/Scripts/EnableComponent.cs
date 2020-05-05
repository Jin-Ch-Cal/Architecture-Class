using System.Collections;
using System.Collections.Generic;
using Unity.DocZh.Models.Json;
using UnityEngine;

public class EnableComponent : MonoBehaviour
{
    public GameObject sketchCube;
    public GameObject blueModel;
    private SketchMovement sketchMovement;
    private SketchFace sketchFace;
    private ModelMovement modelMovement;

    private void Awake()
    {
        sketchMovement = sketchCube.GetComponent<SketchMovement>();
        sketchFace = sketchCube.GetComponent<SketchFace>();
        modelMovement = blueModel.GetComponent<ModelMovement>();

        sketchMovement.enabled = false;
        sketchFace.enabled = false;
        modelMovement.enabled = false;

    }

    public void EnableSketchMove()
    {
        sketchMovement.enabled = !sketchMovement.enabled;
        
    }

    public void EnableSketchFace()
    {
        sketchFace.enabled = !sketchFace.enabled;
    }

    public void EnableModelMove()
    {
        
        modelMovement.enabled = !modelMovement.enabled;
    }
}

