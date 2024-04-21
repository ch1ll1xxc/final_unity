using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControlller : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float sprintSpeed = 10f;
    public float gravity = -9.8f;
    public float jumpHeight = 10f;

    private bool isGrounded;
    private bool isSprinting;
    private bool isCrouched;
    private bool isWalking;

    private CharacterController characterController;
    private Animator animator;

    void Start(){
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");
        Vector3 moveDirection = transform.right * horizontalMovement + transform.forward * verticalMovement;

        bool isSprinting = Input.GetKey(KeyCode.LeftShift);
        bool isCrouched = Input.GetKey(KeyCode.LeftControl);
        animator.SetBool("isCrouched", isCrouched);
        animator.SetBool("isRunning", isSprinting);
        float currentSpeed = isSprinting ? sprintSpeed : movementSpeed;
        animator.SetBool("isWalking", horizontalMovement!=0 || verticalMovement!=0);

        Vector3 a = Vector3.zero;
        if (!characterController.isGrounded){
            print("down"+" "+characterController.isGrounded);
            a.y += gravity/10;
        }
        if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
        {
            print("jump");
            a.y = jumpHeight;
        }
        characterController.Move(((moveDirection * currentSpeed)+a) * Time.deltaTime);


    }
}
