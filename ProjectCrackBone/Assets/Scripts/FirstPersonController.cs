using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstPersonController : MonoBehaviour
{
    private Rigidbody rb;
    [Header("Gun(s)")]
    public GameObject revolver;
    Animator revolverAnim;

    [Header ("Cam")]
    public Camera playerCamera;
    public float fov = 60f;
    public static bool cameraCanMove = true;
    public float mouseSensitivity = 2f;
    public float maxLookAngle = 50f;

    [Header("Crosshair")]
    public Sprite crosshairImage;
    public Color crosshairColor = Color.white;

    private float yaw;
    private float pitch;
    private Image crosshairObject;
   
   
    [Header ("Walk Vaues")]
    public bool playerCanMove = true;
    public float walkSpeed = 5f;
    public float maxVelocityChange = 10f;


    [Header("Run Values")]
    KeyCode sprintKey = KeyCode.LeftShift;
    public float sprintSpeed = 7f;

   [Header("Jump Values")]
    KeyCode jumpKey = KeyCode.Space;
    public float jumpPower;

    // Internal Variables
    private bool isGrounded = false;

   

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        crosshairObject = GetComponentInChildren<Image>();
        playerCamera.fieldOfView = fov;
    }

    void Start()
    {   
        Cursor.lockState = CursorLockMode.Locked;
        crosshairObject.sprite = crosshairImage;
        crosshairObject.color = crosshairColor;
        revolverAnim = revolver.GetComponent<Animator>();
    }

    private void Update()
    {

        if(cameraCanMove)
        {
            CamMove();
        }


        if(Input.GetKeyDown(jumpKey) && isGrounded)
        {
            Jump();
        }

        CheckGround();
    }

    void FixedUpdate()
    {
        if (playerCanMove)
        {
            Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            if (Input.GetKey(sprintKey))
            {
                Running(targetVelocity);
            }
            else
            {
                Walking(targetVelocity);
            }
            if (Input.GetAxis("Horizontal") > .5f || Input.GetAxis("Vertical") > .5f)
            {
                revolverAnim.SetFloat("Speed", 1);
            }
            else
            {
                revolverAnim.SetFloat("Speed", 0);
            }
        }
    }

    
    private void CheckGround()
    {
        Vector3 origin = new Vector3(transform.position.x, transform.position.y - (transform.localScale.y * .5f), transform.position.z);
        Vector3 direction = transform.TransformDirection(Vector3.down);
        float distance = .75f;

        if (Physics.Raycast(origin, direction, out RaycastHit hit, distance))
        {
            Debug.DrawRay(origin, direction * distance, Color.red);
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(0f, jumpPower, 0f, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void Running(Vector3 targetVelocity)
    {
        targetVelocity = transform.TransformDirection(targetVelocity) * sprintSpeed;

        Vector3 velocity = rb.velocity;
        Vector3 velocityChange = (targetVelocity - velocity);
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
        velocityChange.y = 0;

        rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }

    void Walking(Vector3 targetVelocity)
    {
        targetVelocity = transform.TransformDirection(targetVelocity) * walkSpeed;

        Vector3 velocity = rb.velocity;
        Vector3 velocityChange = (targetVelocity - velocity);
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
        velocityChange.y = 0;
        rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }

    void CamMove()
    {
        yaw = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= mouseSensitivity * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -maxLookAngle, maxLookAngle);
        transform.localEulerAngles = new Vector3(0, yaw, 0);
        playerCamera.transform.localEulerAngles = new Vector3(pitch, 0, 0);
    }
}