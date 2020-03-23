using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private Vector3 posA;
    private Vector3 posB;
    private Vector3 nextPosition;
    
    public GameManagerController _gameController;
    [SerializeField] private float speed;
    [SerializeField] private Transform childTransform;
    [SerializeField] private Transform transformB;

    private void Start()
    {
        _gameController = GameManagerController.Instance;
        posA = childTransform.localPosition;
        posB = transformB.localPosition;
        nextPosition = posB;
    }

    // Update is called once per frame
    void Update()
    {
        PlatformMove();
    }

    public void PlatformMove()
    {
        if (_gameController.tudoJunto == true)
        {
            Debug.Log("plataforma mexeu");
            childTransform.localPosition =
                Vector3.MoveTowards(childTransform.localPosition, nextPosition, speed * Time.deltaTime);

            if (Vector3.Distance(childTransform.localPosition, nextPosition) <= 0.1)
            {
                ChangeDestination();
            }
        }
    }

    private void ChangeDestination()
    {
        nextPosition = nextPosition != posA ? posA : posB;
    }
    
}
