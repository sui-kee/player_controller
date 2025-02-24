using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Skeleton skeleton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("skeletonSword"))
        {
            player.isHurt = true;
            float attackDirection = (skeleton.sk_rb.position.x < player.rb.position.x) ? 1f : -1f;
            StartCoroutine(player.PlayerHurt(15 * attackDirection));
        }
    }
}
