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
    public bool onWall;
    public bool onRWall;
    public bool onLWall;
    public bool cellingCheck;
    public int wallSide;
    public bool seeThroughWall;
    [Space] [Header("Collision")] 
    

    public float collisionRadius = 0.25f;
    public Vector2 bottomOffset, rightOffset, leftOffset, upOffset;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        onGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, groundLayer);
        cellingCheck = Physics2D.OverlapCircle((Vector2)transform.position + upOffset, collisionRadius, groundLayer);
        onWall = Physics2D.OverlapCircle((Vector2) transform.position + rightOffset , collisionRadius,
            groundLayer)||Physics2D.OverlapCircle((Vector2) transform.position + leftOffset , collisionRadius,
                     groundLayer);
        wallSide = onRWall ? -1 : 1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        var positions = new Vector2[]{bottomOffset,rightOffset,leftOffset};
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + upOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, collisionRadius);
        Gizmos.DrawRay(transform.position,direction: Vector3.back);
    }
}
