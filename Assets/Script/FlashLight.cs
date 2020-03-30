using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] private bool flashLightEnabled;
    public GameObject flashLight;
    public GameObject lightObj;
    [SerializeField] private float maxEnergy;
    [SerializeField] private float currentEnergy;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashLightEnabled =! flashLightEnabled;
        }
        flashLight.SetActive(flashLightEnabled);
    }
}
