using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchModeTrigger : MonoBehaviour
{
    [SerializeField] private SwitchType switchType;
    [SerializeField] private LayerMask playerLayerMask;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (1 << collision.gameObject.layer == playerLayerMask.value)
        {
            if (switchType == SwitchType.RunningToFlying)
            {
                collision.GetComponent<PlayerController>().SwitchToFlyingMode();
            }
            else
            {
                collision.GetComponent<PlayerController>().SwitchToRunningMode();
            }
        }
    }
}

public enum SwitchType
{
    RunningToFlying,
    FlyingToRunning
}