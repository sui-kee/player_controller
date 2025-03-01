using UnityEngine;

public class Hole1 : MonoBehaviour
{
    [SerializeField] private Transform anotherHolePos;
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
        collision.gameObject.transform.position = anotherHolePos.position;
    }
}
