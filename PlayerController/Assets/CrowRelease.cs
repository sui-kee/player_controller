using System.Collections;
using UnityEngine;

public class CrowRelease : MonoBehaviour
{
    [SerializeField] private GameObject crow;
    [SerializeField] private Player player;
    [SerializeField] private Transform shootingPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c") && !player.playerIsAttacking)
        {
            player.comingAnimation = "CrowAttack";
            StartCoroutine(PlayerShoot());
        }

    }
    // player shooting animation
    public IEnumerator PlayerShoot()
    {
        if (player.canShoot)
        {
            player.canShoot = false;
            player.playerIsAttacking = true;
            player.comingAnimation = "CrowAttack";
            yield return new WaitForSeconds(1.05f);
            Instantiate(crow, shootingPoint.position, shootingPoint.rotation);
            player.playerIsAttacking = false;
            yield return new WaitForSeconds(1f);
            player.canShoot = true;
        }
    }
}
