using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    //Plyer controller
    [SerializeField] CharacterController playerController;

    //Movement Variables
    [SerializeField] private Vector3 movePlayer;
    [SerializeField] float playerSpeed = 12f;
    [SerializeField] private float gravity = -9.8f;

    //Camera atributes
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Vector3 camForward;
    [SerializeField] private Vector3 camRight;


    //Floor layerMask
    LayerMask floor = 1 << 6;

    //The max distace the player can be to the border od the floor
    const float MAX_EDGE_DISTANCE = 20f;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
   
    }

    // Update is called once per frame
    void Update()
    {
        //Get the player imputs
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

       
        Vector3 playerInput = new Vector3(xInput, 0, yInput);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);
        camDirection();

        Vector3 camMovement = playerInput.x * camRight + playerInput.z * camForward;

       
        Vector3 newMovePlayer = camMovement * playerSpeed * Time.deltaTime;
        SetGravity();



        Debug.DrawRay(playerController.transform.position - new Vector3(0f, 0.8f, 0f), camMovement, Color.red);


        if (willBeGrounded(playerController.transform.position + (camMovement * playerSpeed * Time.deltaTime)* MAX_EDGE_DISTANCE))
        {
            movePlayer += newMovePlayer;

            playerController.transform.LookAt(transform.position - camMovement);
        }


        playerController.Move(movePlayer);



    } 

    private void SetGravity()
    {
        movePlayer = new Vector3 (0f,  gravity*Time.deltaTime, 0f);
    }

    void camDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;
        camForward = camForward.normalized;
        camRight = camRight.normalized;

    }

    bool willBeGrounded(Vector3 newPosition)
    {
    
        float extraHeight = 2f;
       return  Physics.Raycast(newPosition, Vector3.down, extraHeight, floor)?  true :  false;
       
     
    }

    bool autoJump(Vector3 newPositionTop, Vector3 newPositionBottom, Vector3 lookAtDir)
    {
        return (!Physics.Raycast(newPositionTop, lookAtDir, 3f, floor)
            && Physics.Raycast(newPositionBottom, lookAtDir, 3f, floor)) ? true : false;
    }
}

