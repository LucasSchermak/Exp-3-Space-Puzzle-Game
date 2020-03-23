using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameManagerController : MonoBehaviour
{
    public static GameManagerController Instance;
    public bool interagindo1 = false;
    public bool interagindo2 = false;
    public bool onButton1 = false;
    public bool onButton2 = false;
    public bool tudoJunto = false;
 
    private void Start()
    {

        if (Instance == null)             
            Instance = this;
    }
    private void Update()
    {
        if (onButton1 && onButton2)
        {
            Interact(interact1: interagindo1, interact2: interagindo2);
        }
    }
    public void Interact(bool interact1, bool interact2)
    {
         if (interact1 && interact2)
         {
             Debug.Log("funciona");
             tudoJunto = true;
         }else
             Debug.Log("não funciona");
    }
    

}


