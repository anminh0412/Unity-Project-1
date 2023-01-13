using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private float moveInput;

    private bool isGrounded;
    private bool isFall = false;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping = false;

    public Animator animator;

    [HideInInspector] public bool isFacingRight;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      
    }
    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2 (moveInput * speed, rb.velocity.y);
        animator.SetFloat("playerSpeed", Mathf.Abs(moveInput));
    }
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            isFacingRight = true;
        } else if(moveInput < 0)
        {
            
            transform.eulerAngles = new Vector3(0, 180, 0);
            isFacingRight = false;
        }
        
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space) || isGrounded == true && Input.GetKeyDown(KeyCode.W) || isGrounded == true && Input.GetKeyDown(KeyCode.UpArrow))
        {
            isJumping = true;
            animator.SetBool("isJumping", true);
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }
        if (Input.GetKey(KeyCode.Space) && isJumping == true || Input.GetKey(KeyCode.W) && isJumping == true || Input.GetKey(KeyCode.UpArrow) && isJumping == true)
        {
            if(jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
                animator.SetBool("isJumping", false);
            }
        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            isJumping = false;
            animator.SetBool("isJumping", false);
        }
        if (isGrounded == false && isJumping == false)
        {
            GameObject.Find("MovementSoundManager").GetComponent<MovementSoundManager>().audioSrc.Stop();
            animator.SetBool("isFall", true);
            isFall = true;
        }else if (isGrounded == true && isJumping == false && isFall == true)
        {
            animator.SetBool("isFall", false);
            GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySound("playerFallOver");
            isFall = false;
        }
        else 
        { 
            animator.SetBool("isFall", false);
        }
  
        //Doan nay vua nhay vua chay pro vailon ditme gamevui.vn toan thang ngu
        if (isJumping == true)
        {
            if (!GameObject.Find("JumpSoundManager").GetComponent<JumpSoundManager>().audioSrc.isPlaying)
            {
                GameObject.Find("JumpSoundManager").GetComponent<JumpSoundManager>().PlaySound();
            }
            if (GameObject.Find("MovementSoundManager").GetComponent<MovementSoundManager>().audioSrc.isPlaying)
            {
                GameObject.Find("MovementSoundManager").GetComponent<MovementSoundManager>().audioSrc.Stop();
            }     
        }
        else if (moveInput != 0)
        {
            if (!GameObject.Find("MovementSoundManager").GetComponent<MovementSoundManager>().audioSrc.isPlaying)
            {
                GameObject.Find("MovementSoundManager").GetComponent<MovementSoundManager>().PlaySound("run");
            }
        }
        else 
        {
            GameObject.Find("MovementSoundManager").GetComponent<MovementSoundManager>().audioSrc.Stop();
            GameObject.Find("JumpSoundManager").GetComponent<JumpSoundManager>().audioSrc.Stop();
        }
    }   
}
