using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsCharacterController : MonoBehaviour
{
    PlayerMovement character;
    Rigidbody2D rgbd2d;
    [SerializeField] float offsetDistance;
    [SerializeField] float sizeOfInteractableArea;

    private void Awake()
    {
        character = GetComponent<PlayerMovement>();
        rgbd2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            UseTool();
        }
    }

    private void UseTool()
    {
        //Vector3 position = rgbd2d.position + character.change * offsetDistance;
        Vector2 position = rgbd2d.position + character.lastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (Collider2D c in  colliders)
        {
            ToolHit hit = c.GetComponent<ToolHit>();
            if(hit != null)
            {
                hit.Hit();
                break;
            }
        }
    }
}
