using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] Transform playerCam;
    Vector2 look;
 

    [SerializeField] float mouseSensitivity = 3f;
    [SerializeField] float movementSpeed = 5f;

    CharacterController controller;
    Rigidbody rigidbody;
    public float gravityScale = 1.0f;
    public static float globalGravity = -9.81f;

    void Awake(){
        controller = GetComponent<CharacterController>();
        rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        looking();
        movement();
    }

    private void FixedUpdate()
    {
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        rigidbody.AddForce(gravity, ForceMode.Acceleration);
    }

    void looking(){
        look.x += Input.GetAxis("Mouse X") * mouseSensitivity;
        look.y += Input.GetAxis("Mouse Y") * -mouseSensitivity;

        look.y = Mathf.Clamp(look.y,-89f,89f);

        transform.localRotation = Quaternion.Euler(0,look.x,0);
        playerCam.localRotation = Quaternion.Euler(look.y,0,0);
    }

    void movement(){
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        var jump = Input.GetAxis("Jump");

        //Debug.Log("x = " + x);

        var input = new Vector3();
        input += transform.forward * y;
        input += transform.right * x;
        input += transform.up * jump;
        input = Vector3.ClampMagnitude(input,1f);

        // transform.Translate(input * movementSpeed * Time.deltaTime,Space.World);
        //controller.Move(input * movementSpeed * Time.deltaTime);

        //rigidbody.MovePosition(transform.position + (input * Time.deltaTime * movementSpeed));
        rigidbody.AddForce(input * movementSpeed);

    }
}
