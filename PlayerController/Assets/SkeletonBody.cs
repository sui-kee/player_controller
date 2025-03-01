using UnityEngine;

public class SkeletonBody : MonoBehaviour
{
    [SerializeField] private Skeleton skeleton;
    [SerializeField] private Level1Logistic level1;
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
        if (collision.CompareTag("playerArrow") || collision.CompareTag("crowDamageBody"))
        {
            if (!skeleton.isInvincible)
            {
                level1.enemyCounts--;
                StartCoroutine(skeleton.SkeletonDead());
            }
        }
    }
}
