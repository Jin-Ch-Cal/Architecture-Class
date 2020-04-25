using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTramsform : MonoBehaviour
{
    public GameObject model;

    UnityEngine.Vector3 deltaPosition;
    UnityEngine.Vector3 bInitialPostion;


    void Start()
    {
        bInitialPostion = transform.position;
        deltaPosition = transform.position - model.transform.position;

    }

    void Update()
    {
        transform.rotation = model.transform.rotation; //Follow rotation.
        transform.position = model.transform.position * 250 + deltaPosition * 250 - bInitialPostion * 249; //Follow position.
        transform.localScale = model.transform.localScale * 250; //Follow scale.

    }
}
