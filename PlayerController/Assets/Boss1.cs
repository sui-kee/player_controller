using System.Collections;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Animator animator;
    [SerializeField] private Level1Logistic level1;
    [SerializeField] private Rigidbody2D sk_rb;
    public string currentAnimation = "SkeletonRun";
    public string incomingAnimation = "";
    public bool isFacingRight = true;
    public float runningSpeed = 4f;
    public bool isIdle = false;
    public bool isAttacking = false;
    public bool isHurt = false;
    public bool isDying = false;
    public bool isInvincible = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void MoveToPosition()

    {
        if (!isIdle && !isDying && !isAttacking)
        {
            float direction = isFacingRight ? 1f : -1f;
            sk_rb.linearVelocity = new Vector2(direction * runningSpeed, sk_rb.linearVelocity.y);
        }

    }
    private void SkeletonIdleController()
    {
        if (player.rb.position.y > -2 && !isHurt && !isDying)
        {
            isIdle = true;
            incomingAnimation = "SkeletonIdle";
        }
        if (player.rb.position.y < -2)
        {
            isIdle = false;
        }
    }
    private void SkeletonMovementController()
    {
        if (!isIdle && !isAttacking && !isHurt && !isDying)
        {
            incomingAnimation = "SkeletonRun";
        }
    }
    public void ChangeAnimation(string animation, float crossFade = 0.2f)
    {
        if (currentAnimation != animation)
        {
            currentAnimation = animation;
            animator.CrossFade(animation, crossFade);
        }
    }

   
    public void Flip()
    {
        //Vector3 localScale = transform.localScale;
        //localScale.x *= -1f;
        //transform.localScale = localScale;
        transform.Rotate(0f, 180f, 0f);

    }

    private void SkeletonAnimatorController()
    {
        switch (incomingAnimation)
        {
            case "Boss1Dead":
                ChangeAnimation("Boss1Dead");
                break;
            case "Boss1Attack":
                ChangeAnimation("Boss1Attack", 0.2f);
                break;
            case "Boss1Protect":
                ChangeAnimation("Boss1Protect", 0f);
                break;
            case "Boss1Run":
                ChangeAnimation("Boss1Run", 0.2f);
                break;
            case "Boss1Idle":
                ChangeAnimation("Boss1Idle");
                break;
        }
    }

}
