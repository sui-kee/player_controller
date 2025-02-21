using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    [SerializeField] private Player player;
    [SerializeField] private Transform shootingPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f") && !player.playerIsAttacking)
        {
            player.comingAnimation = "PlayerShoot";
            StartCoroutine(PlayerShoot());
        }
        
    }
    // player shooting animation
    public IEnumerator PlayerShoot()
    {
        player.playerIsAttacking = true;
        player.comingAnimation = "PlayerShoot";
        yield return new WaitForSeconds(0.20f);
        Instantiate(arrow, shootingPoint.position,shootingPoint.rotation);
        player.playerIsAttacking = false;
    }
}
