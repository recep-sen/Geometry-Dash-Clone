using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpMultiplier;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            rb.AddForce(Vector2.up * JumpMultiplier, ForceMode2D.Impulse);
        }
    }
}