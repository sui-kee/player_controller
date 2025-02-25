using UnityEngine;

public class GateOne : MonoBehaviour
{
    public bool gateShouldOpen = false;
    public float openingSpeed = 1f;
    public float gateOffset = -5.30f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log($"original gate pos y: {transform.position.y}");
    }

    // Update is called once per frame
    void Update()
    {
        if (gateShouldOpen)
        {
            transform.position += 1 * Time.deltaTime * -transform.up;
        }
        if (transform.position.y < gateOffset)
        {
            Debug.Log("Destroy gate.....");
            Destroy(gameObject);
        }
    }
}
