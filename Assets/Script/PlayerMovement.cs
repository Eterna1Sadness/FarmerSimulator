using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidBody;
    public Vector2 change;
    public Vector2 lastMotionVector;
    private Animator animator;
    public VectorValue startingPosition;
    public Vector2 position;

    GameSceneManager currentScene;
    string scene;

    private void Awake()
    {
        transform.position = startingPosition.initialValue;
    }

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        currentScene = GetComponent<GameSceneManager>();
    }

    void Update()
    {
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        animator.SetBool("moving", true);

        UpdateAnimationAndMove();
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector2.zero)
        {
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        myRigidBody.MovePosition(myRigidBody.position + change * speed * Time.fixedDeltaTime);
    }
    
    public void SavePlayer()
    {
        var camera = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
        var timeController = GameObject.Find("GameManager").GetComponent<DayTimeController>();
        var scene = GameObject.Find("GameManager").GetComponent<GameSceneManager>();

        SaveSystem.SavePlayer(this, camera, timeController, scene);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        var camera = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
        var timeController = GameObject.Find("GameManager").GetComponent<DayTimeController>();
        var scene = GameObject.Find("GameManager").GetComponent<GameSceneManager>();

        Vector2 position;

        position.x = data.playerPosition[0];
        position.y = data.playerPosition[1];

        transform.position = new Vector3(position.x, position.y, 0);

        Vector2 maxPos;
        maxPos.x = data.maxPositionX;
        maxPos.y = data.maxPositionY;

        Vector2 minPos;
        minPos.x = data.minPositionX;
        minPos.y = data.minPositionY;

        camera.maxPosition = new Vector2(maxPos.x, maxPos.y);
        camera.minPosition = new Vector2(minPos.x, minPos.y);

        timeController.time = data.time;

        SceneManager.UnloadSceneAsync(scene.currentScene);
        scene.currentScene = data.scene;
        SceneManager.LoadScene(scene.currentScene, LoadSceneMode.Additive);
    }
}
