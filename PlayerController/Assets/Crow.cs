using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Crow : MonoBehaviour
{
    public List<Collider2D> enemiesInRange = new();
    public Collider2D closestTarget = null;
    public bool isFacingRight = true;
    public float speed = 4f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("skeletonFBody")) // Filter by tag
        {
            enemiesInRange.Add(other);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("skeletonFBody")) // Remove from list when out of range
        {
            enemiesInRange.Remove(other);
        }
    }

    void Update()
    {

        FindClosestEnemy();
        if (closestTarget)
        {
            MoveTowardsTarget();
            if (isFacingRight && transform.position.x > closestTarget.transform.position.x )
            {
                Flip();
            }
            else if (!isFacingRight && transform.position.x < closestTarget.transform.position.x)
            {
                Flip();
            }
        }
    }

    private void Flip()
    {
            isFacingRight = !isFacingRight;
            //Vector3 localScale = transform.localScale;
            //localScale.x *= -1f;
            //transform.localScale = localScale;
            transform.Rotate(0f, 180f, 0f);
    }

    void FindClosestEnemy()
    {
        float closestDistance = Mathf.Infinity;
        closestTarget = null;

        foreach (Collider2D enemy in enemiesInRange)
        {
            if (enemy != null) // Check if enemy still exists
            {
                float distance = Vector2.Distance(transform.position, enemy.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestTarget = enemy;
                }
            }
        }

        if (closestTarget != null)
        {
            Debug.Log("Closest Enemy: " + closestTarget.gameObject.name);
        }
    }
    void MoveTowardsTarget()
    {
        if (closestTarget != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, closestTarget.transform.position, speed * Time.deltaTime);
        }
    }
}
