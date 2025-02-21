using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public float arrowSpeed = 5f;
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
        if (collision.CompareTag("wall"))
        {
            Destroy(gameObject);
        }
    }
}
