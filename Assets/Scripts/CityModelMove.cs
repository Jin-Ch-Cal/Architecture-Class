using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityModelMove : MonoBehaviour
{
    public GameObject player;
    Vector3 cInitialPosition;
    Vector3 pInitialPosition;

    void Awake()
    {
        cInitialPosition = transform.position;
        pInitialPosition = player.transform.position;
    }

    void Update()
    {
        transform.position = player.transform.position - pInitialPosition + cInitialPosition;
    }
}
