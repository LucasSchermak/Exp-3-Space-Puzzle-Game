using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [Header("Layers")]
    
    public LayerMask groundLayer;

    [Space]

    public bool onGround;
    [SerializeField]private bool onWall;
    [SerializeField]private bool cellingCheck;
    [SerializeField]private bool seeThroughWall;
    [Space] [Header("Collision")] 
    
    [SerializeField]private float collisionRadius = 0.25f;
    [SerializeField]private Vector2 bottomOffset, upOffset;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, groundLayer);
        cellingCheck = Physics2D.OverlapCircle((Vector2)transform.position + upOffset, collisionRadius, groundLayer);
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + upOffset, collisionRadius);
        Gizmos.DrawRay(transform.position,direction: Vector3.back);
    }
}
