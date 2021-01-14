using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    
    private Vector3 playerInput;
    public Animation weaponAnim;
    public CharacterController player;
    private Vector3 movePlayer;
    public float speed = 6f;
    public int lastRoom = -1;    
    
    public float gravity = 9.81f;
    public float fallSpeed;
    public float jumpForce;

    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;

    void Start() {
        weaponAnim = GetComponent<Animation>();
    }

    void FixedUpdate () {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Move(h, v);
    }

    public void Move(float h, float v) {
        playerInput = new Vector3(h, 0f, v);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        Turning ();

        movePlayer = playerInput.x * camRight + playerInput.z * camForward;
        movePlayer = movePlayer * speed;

        SetGravity();

        PlayerSkills();
        player.Move(movePlayer * Time.deltaTime);
    }   

    void Turning ()  {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;
    }
    
    void SetGravity() {
        if(player.isGrounded) {
            fallSpeed = -gravity * Time.deltaTime;
            movePlayer.y = fallSpeed;
        }
        else {
            fallSpeed -= gravity * Time.deltaTime;  
            movePlayer.y = fallSpeed;          
        }
    }

    void PlayerSkills() {
        if(player.isGrounded && Input.GetButtonDown("Jump")) {
            fallSpeed = jumpForce;
            movePlayer.y = fallSpeed;
        }
    }
}
