using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.DocZh.Models.Json;
using UnityEngine;

public class EnableComponent : MonoBehaviour
{
    public GameObject sketchCube;
    public GameObject blueModel;
    public GameObject cityModelFollow;
    private SketchMovement sketchMovement;
    private SketchFace sketchFace;
    private MoveVertice moveVertice;
    private ModelMovement modelMovement;

    public bool show = false;
    

    private void Awake()
    {
        sketchMovement = sketchCube.GetComponent<SketchMovement>();
        sketchFace = sketchCube.GetComponent<SketchFace>();
        moveVertice = sketchCube.GetComponent<MoveVertice>();
        modelMovement = blueModel.GetComponent<ModelMovement>();

        DisableAllComponent();

        show = false;
        cityModelFollow.SetActive(show);


    }

    public void DisableAllComponent()
    {
        sketchMovement.enabled = false;
        
        modelMovement.enabled = false;
    }

    public void EnableSketchMove()
    {
        DisableAllComponent();
        sketchMovement.enabled = !sketchMovement.enabled;
    }

    public void EnableSketchFace()
    {
        DisableAllComponent();
        sketchFace.enabled = !sketchFace.enabled;
    }

    public void EnableMoveVertice()
    {
        DisableAllComponent();
        moveVertice.enabled = !moveVertice.enabled;
    }

    public void EnableModelMove()
    {
        DisableAllComponent();
        modelMovement.enabled = !modelMovement.enabled;
    }

    public void SwitchCityModelFollow()
    {
        show = !show;
        cityModelFollow.SetActive(show);
    }
}

