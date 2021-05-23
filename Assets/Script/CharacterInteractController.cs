using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractController : MonoBehaviour
{
    PlayerMovement characterController;
    Rigidbody2D rgbd2d;
    [SerializeField] float offsetDistance = 0.5f;
    [SerializeField] float sizeOfInteractableArea = 0.5f;
    Character character;
    

    private void Awake()
    {
        characterController = GetComponent<PlayerMovement>();
        rgbd2d = GetComponent<Rigidbody2D>();
        character = GetComponent<Character>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Interact();
        }
    }

    private void Interact()
    {
        //Vector3 position = rgbd2d.position + character.change * offsetDistance;
        Vector2 position = rgbd2d.position + characterController.lastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (Collider2D c in colliders)
        {
            Interactable hit = c.GetComponent<Interactable>();
            if (hit != null)
            {
                hit.Interact();
                break;
            }
        }
    } 
}
