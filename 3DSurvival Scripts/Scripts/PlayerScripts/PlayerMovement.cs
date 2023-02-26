using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;



public class PlayerMovement : MonoBehaviour
{
    //Refrences
    CharacterController player;
    public Transform cameraEyes;
    public Transform groundCheck;
    //Movement/Rotation Variables
    float mouseX, mouseY, cameraX;
    float xMove, zMove;
    float mouseSens = 500f, speed = 7f;
    Vector3 Move = new Vector3();
    bool isRunning;
    bool isWalking;
    bool isWalkingBackward;
    bool attack;
    public Animator animControl;
    public static int playerDamage = 25;
    public static bool playerInTreeRange;
    public static bool playerInRockRange;
    //Physics
    bool isGround;
    float radius = 0.3f, gravity = -9.8f;
    public LayerMask groundMask;
    Vector3 gVelocity;
    //Audios
    public AudioClip wallkingClip;
    public AudioSource wallkingSource;
    public AudioClip swingClip;
    public AudioSource swingSource;

    void Start()
    {
        player = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        isWalking = false;
        isRunning = false;
        isWalkingBackward = false;
        attack = false;
    }
    void Update()
    {
        getData();
        physicManager();
        Movement();
        Rotation();
        RunningAndJumpingAndAttacking();
        Animation();
        playerAudios();
    }
    void getData()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;
        xMove = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        zMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
    }
    void Movement()
    {
        Move = transform.forward * xMove + transform.right * zMove;
        player.Move(Move);

        if (Input.GetButtonDown("Jump") && isGround)
        {
            gVelocity.y = Mathf.Sqrt(2f * -2f * gravity);
        }
    }
    void Rotation()
    {
        transform.Rotate(0, mouseX, 0);
        cameraX -= mouseY;
        cameraX = Mathf.Clamp(cameraX, -80, 80);
        cameraEyes.localRotation = Quaternion.Euler(cameraX, 0, 0);
    }
    void Animation()
    {
        if (isWalking)
        {
            animControl.SetBool("isWalking", true);
        }
        else
        {
            animControl.SetBool("isWalking", false);
        }

        if (isRunning)
        {
            animControl.SetBool("isRunning", true);
        }
        else
        {
            animControl.SetBool("isRunning", false);
        }

        if (isWalkingBackward)
        {
            animControl.SetBool("isWalkingBackward", true);
        }
        else
        {
            animControl.SetBool("isWalkingBackward", false);
        }

        if (Input.GetMouseButtonDown(0) && CraftingSystem.isOpen == false)
        {
            attack = true;
            swingSource.PlayOneShot(swingClip);
        }
        else
        {
            attack = false;
        }
    }
    void RunningAndJumpingAndAttacking()
    {
        if (Input.GetKey(KeyCode.W))
        {
            isWalking = true;
            isRunning = false;
            isWalkingBackward = false;
        }
        else
        {
            isWalking = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            isWalking = false;
            isRunning = false;
            isWalkingBackward = true;
        }
        else
        {
            isWalkingBackward = false;
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            speed = 12f;
            isWalking = false;
            isRunning = true;
            isWalkingBackward = false;
        }
        else
        {
            speed = 7f;
            isRunning = false;
        }

        if (attack)
        {
            animControl.SetBool("swing", true);
        }
        else
        {
            animControl.SetBool("swing", false);
        }
    }
    void physicManager()
    {
        isGround = Physics.CheckSphere(groundCheck.position, radius, groundMask);
        if (isGround && gVelocity.y < 0)
        {
            gVelocity.y = -2f;
        }

        gVelocity.y += gravity * Time.deltaTime;
        player.Move(gVelocity * Time.deltaTime);
    }
    void playerAudios()
    {
        if (isGround && Move.magnitude != 0 && wallkingSource.isPlaying == false)
        {
            
            wallkingSource.PlayOneShot(wallkingClip);
        }
        if (Move.magnitude == 0 && wallkingSource.isPlaying == true || isGround == false && wallkingSource.isPlaying == true)       
        {
            wallkingSource.Stop();
        }
        
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            playerInTreeRange = true;
        }
        if (other.CompareTag("Rock"))
        {
            playerInRockRange = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            playerInTreeRange = false;
        }
        if (other.CompareTag("Rock"))
        {
            playerInRockRange = false;
        }
    }

}
