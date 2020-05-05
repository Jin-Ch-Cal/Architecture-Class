using System.Collections;
using System.Collections.Generic;
using Unity.DocZh.Models.Json;
using UnityEngine;

public class EnableComponent : MonoBehaviour
{
    public GameObject sketchCube;
    public GameObject blueModel;
    private SketchMovement sketchMovement;
    private ModelMovement modelMovement;

    private void Awake()
    {
        sketchMovement = sketchCube.GetComponent<SketchMovement>();
        modelMovement = blueModel.GetComponent<ModelMovement>();
    }

    public void EnableSketchMove()
    {
        sketchMovement.enabled = !sketchMovement.enabled;
        
    }

    public void EnableModelMove()
    {
        
        modelMovement.enabled = !modelMovement.enabled;
    }
}

