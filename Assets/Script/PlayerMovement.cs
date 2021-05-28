using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    dig,
    axe,
    pick,
    interact
}

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidBody;
    public Vector2 change;
    public Vector2 lastMotionVector;
    private Animator animator;
    private bool moving;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        change = new Vector2(horizontal, vertical);

        animator.SetFloat("moveX", horizontal);
        animator.SetFloat("moveY", vertical);

        moving = horizontal != 0 || vertical != 0;
        animator.SetBool("moving", moving);

        if (change != Vector2.zero)
        {
            //lastMotionVector = new Vector2(horizontal, vertical).normalized;
            animator.SetFloat("moveX", horizontal);
            animator.SetFloat("moveY", vertical); 
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }

        //change = Vector2.zero;
        //change.x = Input.GetAxisRaw("Horizontal");
        //change.y = Input.GetAxisRaw("Vertical");
        //if (Input.GetButtonDown("dig") && currentState != PlayerState.dig)
        //{
        //    StartCoroutine(DigCo());
        //}
        //else if (Input.GetButtonDown("axe") && currentState != PlayerState.axe)
        //{
        //    StartCoroutine(AxeCo());
        //}
        //else if (Input.GetButtonDown("pick") && currentState != PlayerState.pick)
        //{
        //    StartCoroutine(PickCo());
        //}
        //else if(currentState == PlayerState.walk)
        //{
        //    UpdateAnimationAndMove();
        //}
        //UpdateAnimationAndMove();
    }

    private IEnumerator DigCo()
    {
        animator.SetBool("digging", true);
        currentState = PlayerState.dig;
        yield return null;
        animator.SetBool("digging", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;
    }

    private IEnumerator AxeCo()
    {
        animator.Play("Axing");
        animator.SetBool("axing", true);
        currentState = PlayerState.axe;
        yield return null;
        animator.SetBool("axing", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;
    }

    private IEnumerator PickCo()
    {
        animator.SetBool("picking", true);
        currentState = PlayerState.pick;
        yield return null;
        animator.SetBool("picking", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;
    }

    //void UpdateAnimationAndMove()
    //{
    //    if (change != Vector2.zero)
    //    {
    //        MoveCharacter();
    //        animator.SetFloat("moveX", change.x);
    //        animator.SetFloat("moveY", change.y);
    //        animator.SetBool("moving", true);
    //    }
    //    else
    //    {
    //        animator.SetBool("moving", false);
    //    }
    //}

    //void MoveCharacter()
    //{
    //    myRigidBody.MovePosition(transform.position + change * speed * Time.deltaTime);
    //}

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        myRigidBody.velocity = change * speed;
    }
}
