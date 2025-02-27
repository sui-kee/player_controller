using System.Collections;
using UnityEngine;

public class skeletonAttack : MonoBehaviour
{
    [SerializeField] private Transform detectablePlayer;
    [SerializeField] private GameObject sword;
    [SerializeField] private Skeleton skeleton;
    [SerializeField] private Player player;
    public bool isPlayerOnSight = false;
    public float skeletonAttackForce = 8f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    // skeleton attack animation coroutine
    private IEnumerator SkeletonAttack()
    {
        if (!skeleton.isDying && !skeleton.isAttacking) 
        {
            float attackDirection = (skeleton.sk_rb.position.x < player.rb.position.x) ? 1f : -1f;
            skeleton.isAttacking = true;
            skeleton.incomingAnimation = "SkeletonAttack";
            player.playerHurtingDirection = attackDirection;
            yield return new WaitForSeconds(0.45f);
            skeleton.isAttacking = false;
            sword.SetActive(true);
            // delete the attack sword object that deal damage to player
            yield return new WaitForSeconds(0.1f);
            sword.SetActive(false);
            //Debug.Log(" skeleton wave sword::");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform == detectablePlayer )
        {
            isPlayerOnSight = true;
            StartCoroutine(SkeletonAttack());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform == detectablePlayer )
        {
            isPlayerOnSight = false;
        }
    }
}
