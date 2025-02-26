using UnityEngine;

public class SkeletonLife : MonoBehaviour
{
    [SerializeField] private Skeleton skeleton;
    [SerializeField] private OrbGem OrbGem;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OrbGem.isDestroyed)
        {
            DestroySkeletonProtection();
        }
    }

    public void DestroySkeletonProtection()
    {
        skeleton.isInvincible = false;
        gameObject.SetActive(false);    
    }
}
