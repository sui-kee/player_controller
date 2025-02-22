using System.Collections;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    [SerializeField] private Rigidbody2D sk_rb;
    [SerializeField] private Player player;
    [SerializeField] private Animator animator;
    public string currentAnimation = "SkeletonRun";
    public string incomingAnimation = "";
    public bool isFacingRight = true;
    public float runningSpeed = 4f;
    public bool isIdle = false;
    public bool isAttacking = false;
    public bool isHurt = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sk_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SkeletonIdleController();
        SkeletonMovementController();
        if (isFacingRight && sk_rb.position.x > player.rb.position.x )
            {
                ChangeBossFacingDir();
            }
            else if (!isFacingRight && sk_rb.position.x < player.rb.position.x)
            {
                ChangeBossFacingDir();
            }
            MoveToPosition();
        SkeletonAnimatorController();
        Debug.Log($"Player y pos: {player.rb.position.y}");
        
    }
    private void MoveToPosition()

    {
        if(!isIdle)
        {
            float direction = isFacingRight ? 1f : -1f;
            sk_rb.linearVelocity = new Vector2(direction * runningSpeed, sk_rb.linearVelocity.y);
        }

    }
    private void SkeletonIdleController()
    {
        if (player.rb.position.y > -2 && !isHurt)
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
        if( !isIdle && !isAttacking && !isHurt)
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

    //Skeleton Hurt animation
    private IEnumerator SkeletonHurt()
    {
        incomingAnimation = "SkeletonHurt";
        yield return new WaitForSeconds(0.44f);
    }

    private IEnumerator SkeletonProtect()
    {
        isHurt = true;
        incomingAnimation = "SkeletonProtect";
        yield return new WaitForSeconds(0.30f);
        isHurt = false;
    }
    public void ChangeBossFacingDir()
    {

        isFacingRight = !isFacingRight;
        Flip();
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
            case "SkeletonDead":
                ChangeAnimation("SkeletonProtect", 0.2f);
                break;
            case "SkeletonAttack":
                ChangeAnimation("SkeletonAttack", 0.2f);
                break;
            case "SkeletonProtect":
                ChangeAnimation("SkeletonProtect", 0f);
                break;
            case "SkeletonRun":
                ChangeAnimation("SkeletonRun", 0.2f);
                break;
            case "SkeletonIdle":
                ChangeAnimation("SkeletonIdle");
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("playerArrow"))
        {
            StartCoroutine(SkeletonProtect());
        }
    }
}
