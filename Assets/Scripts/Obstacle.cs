using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayerMask;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (1 << collision.collider.gameObject.layer == playerLayerMask.value)
        {
            Debug.Log("Öldün");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (1 << collision.collider.gameObject.layer == playerLayerMask.value)
        {
            Debug.Log("Öldün");
        }
    }
}