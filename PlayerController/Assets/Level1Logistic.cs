using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class Level1Logistic : MonoBehaviour
{
    [SerializeField] private GateOne gate1;
    [SerializeField] private CinemachineCamera PlayerCam;
    [SerializeField] private CinemachineCamera Gate1Cam;
    public float enemyCounts = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCounts < 1 && !gate1.gateShouldOpen)
        {
            StartCoroutine(GateControlling());
        }
    }
    private void ResetCamera()
    {
        PlayerCam.Priority = 20;
        Gate1Cam.Priority = 10;
    }
    private IEnumerator GateControlling()
    {
        PlayerCam.Priority = 10;
        Gate1Cam.Priority = 20;
        yield return new WaitForSeconds(1f);
        gate1.gateShouldOpen = true;
        yield return new WaitForSeconds(0.8f);
        ResetCamera();
    }
}
