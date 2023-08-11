using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Variables")]
    public float MoveSpeed;
    public float JumpMultiplier;
    public float GroundedCheckRayLenght;
    public LayerMask GroundLayerMask;
    [Tooltip("This only affects visually")] public float RotationSpeed;

    [Header("References")]
    public Transform Model;

    private Rigidbody2D rb;
    private bool isGrounded => Physics2D.Raycast(transform.position, Vector2.down, GroundedCheckRayLenght, GroundLayerMask).collider != null;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);

        if(isGrounded)
        {
            Vector3 modelRotation = Model.rotation.eulerAngles;
            modelRotation.z -= modelRotation.z % 90;
            Model.rotation = Quaternion.Euler(modelRotation);
            if (Input.GetMouseButton(0))
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * JumpMultiplier, ForceMode2D.Impulse);
            }
        }
        else
        {
            Model.Rotate(Vector3.back * RotationSpeed * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3.down * GroundedCheckRayLenght));
    }
}