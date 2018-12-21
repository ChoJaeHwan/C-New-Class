using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Animator player=null;
    CharacterController Character = null;
    public Transform cameraTransform;
    public float moveSpeed = 10.0f;

    public float jumpSpeed = 10.0f;
    public float gravity = -20.0f;
    public CameraControl MouseControl = null;
   public float yVelocity = 0.0f;
    // Use this for initialization
    void Start () {
        Character = GetComponent<CharacterController>();
        player = GetComponent<Animator>();
        if (!player)
        {
            Debug.Log("애니메이터가 없음");
            return;
        }

   //     MouseControl = gameObject.AddComponent<CameraControl>();
        
    }
 

    void Update()
    {
        if(Input.GetKey("up")||Input.GetKey("down"))
        {
            player.Play("Run");
        }
        else if(Input.GetButton("Jump"))
        {
            player.Play("jump");

        }
        else
        {
            player.Play("Idle");

        }
        
        float x = Input.GetAxis( "Horizontal" );
        float z = Input.GetAxis( "Vertical" );

        Vector3 moveDirection = new Vector3(x, 0, z);
        moveDirection = cameraTransform.TransformDirection(moveDirection);
        moveDirection *= moveSpeed;
        if (Character.isGrounded == true)
            yVelocity = 0.0f;

        if (Input.GetButtonDown("Jump"))
        { yVelocity = jumpSpeed; }

        yVelocity += (gravity * Time.deltaTime);
        moveDirection.y = yVelocity;
        Character.Move(moveDirection * Time.deltaTime);

        
    }
}
