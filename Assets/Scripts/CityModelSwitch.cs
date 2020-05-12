using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityModelSwitch : MonoBehaviour
{
    private Renderer rend;

    void Awake()
    {
        rend = GetComponent<Renderer>();

    }
    public void EnableCityModelMoveMesh()
    {
        rend.enabled = !rend.enabled;
    }

}
