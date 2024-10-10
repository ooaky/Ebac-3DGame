using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStartCheck : MonoBehaviour
{
    public string tag = "Player";
    public GameObject bossCamera;
    public Color gizmoColor = Color.yellow;

    private void Awake()
    {
        bossCamera.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == tag)
        {
            TurnCameraOn();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == tag)
        {
            TurnCameraOff();
        }
    }

    private void TurnCameraOn()
    {
        bossCamera.SetActive(true);
    }    
    private void TurnCameraOff()
    {
        bossCamera.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawSphere(transform.position, transform.localScale.y);
    }
}
