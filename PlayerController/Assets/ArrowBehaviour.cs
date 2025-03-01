using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public float arrowSpeed = 5f;
    public bool isReturn = false;// for arrow coming back or not
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = transform.right * arrowSpeed;
        Debug.Log("Arrow released!!!!");
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!isReturn && !collision.CompareTag("playerArrow") && !collision.CompareTag("Skeleton") && !collision.CompareTag("Bird") && !collision.CompareTag("hole"))// if the arrows meet  the arrow should not return
        {
            isReturn = true;
            transform.Rotate(0f, 180f, 0f);
            rb.linearVelocity = -rb.linearVelocity;
        }
        else if (isReturn && !collision.CompareTag("Bird"))
        {
            Destroy(gameObject);
        }
    }
}
