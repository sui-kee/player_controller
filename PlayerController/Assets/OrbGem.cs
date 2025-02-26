using UnityEngine;

public class OrbGem : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public bool isGoingUp = false;
    public float orbOriginalPosY;
    public float orbLivePosY;
    public float orbMovingSpeed = 5f;
    public float autoMovingDistance = 2.6f;
    public bool isDestroyed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        orbOriginalPosY = rb.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDestroyed)
        {OrbDistanceController();
        OrbMoving();
            orbLivePosY = rb.position.y;
        }
        else
        {
            rb.gravityScale = 2;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    public void OrbDistanceController()
    {
        if (Mathf.Abs(Mathf.Abs(orbOriginalPosY) - Mathf.Abs(orbLivePosY)) >= autoMovingDistance)
        {
            Debug.Log("orb change direction!!!!!!!!!!!!!!");
            OrbChangeDirection();
            orbOriginalPosY = orbLivePosY;
        }
    }
    private void OrbChangeDirection()
    {
        isGoingUp = !isGoingUp;
        //Flip();
    }

    public void Flip()
    {
        //Vector3 localScale = transform.localScale;
        //localScale.x *= -1f;
        //transform.localScale = localScale;
        transform.Rotate(0f, 180f, 0f);

    }

    public void OrbMoving()// is Facing right or Left will be ajusted from orc body script
    {
        float walkingDirection = isGoingUp ? 1f : -1f;
        rb.linearVelocity = new Vector2( rb.linearVelocity.x, orbMovingSpeed * walkingDirection);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("playerArrow"))
        {
            isDestroyed = true;
        }
    }
}
