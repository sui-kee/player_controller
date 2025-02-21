using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private float horizontal;
    public float speed=4;
    public float jumpingPower = 24;
    public bool isFacingRight = true;
    public string currentAnimation = "PlayerIdle";
    public string comingAnimation = "";
    public bool playerIsAttacking = false;
    public bool isHurt = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x,jumpingPower);

        }
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();
        PlayerMovementDetector();
        PlayerAnimatorController();
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }

    public void ChangeAnimation(string animation, float crossFade = 0.2f)
    {
        if (currentAnimation != animation)
        {
            currentAnimation = animation;
            animator.CrossFade(animation, crossFade);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer);
    }

    public void PlayerMovementDetector()
    {
        if(horizontal != 0 && !playerIsAttacking && IsGrounded() && !isHurt)
        {
            comingAnimation = "PlayerRun";
        }
        if (horizontal == 0 && !playerIsAttacking && IsGrounded() && !isHurt)
        {
            comingAnimation = "PlayerIdle";
        }
        if (!playerIsAttacking && !IsGrounded() && rb.linearVelocity.y > 0 && !isHurt)
        {
            comingAnimation = "PlayerJump";
        }
        if (!playerIsAttacking && !IsGrounded() && rb.linearVelocity.y < 0 && !isHurt)
        {
            comingAnimation = "PlayerFall";
        }
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            //Vector3 localScale = transform.localScale;
            //localScale.x *= -1f;
            //transform.localScale = localScale;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    // player hurt animation
    public IEnumerator PlayerHurt()
    {
        isHurt = true;
        comingAnimation = "PlayerHurt";
        yield return new WaitForSeconds(0.10f);
        isHurt = false;
    }
    private void PlayerAnimatorController()
    {
        switch (comingAnimation)
        {
            case "PlayerShoot":
                Debug.Log("Shoot");
                ChangeAnimation("PlayerShoot", 0.2f);
                break;
            case "PlayerHurt":
                Debug.Log("Hurt");
                ChangeAnimation("PlayerHurt", 0.2f);
                break;
            case "PlayerJump":
                Debug.Log("Jump");
                ChangeAnimation("PlayerJump", 0.2f);
                break;
            case "PlayerFall":
                Debug.Log("Fall");
                ChangeAnimation("PlayerFall", 0.2f);
                break;
            case "PlayerRun":
                Debug.Log("Run");
                ChangeAnimation("PlayerRun", 0.2f);
                break;
            case "PlayerIdle":
                Debug.Log("Idle");
                ChangeAnimation("PlayerIdle", 0.2f);
                break;

        }
    }

}
