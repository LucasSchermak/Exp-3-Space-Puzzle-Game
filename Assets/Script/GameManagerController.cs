using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameManagerController : MonoBehaviour
{
    public static GameManagerController instance;
 
    private void Start()
    {
        if (instance == null)             
            instance = this;
    }

    private void Update()
    {
    }

}


