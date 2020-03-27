using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    private bool flashLightEnabled;
    public GameObject flashLight;
    public GameObject lightObj;
    public float maxEnergy;
    private float currentEnergy;

    public void Start()
    {
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashLightEnabled =! flashLightEnabled;
        }
        flashLight.SetActive(flashLightEnabled);
    }
}
