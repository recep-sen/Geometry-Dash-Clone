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
    public float FlyingGravity;
    [Tooltip("This only affects visually")] public float RotationSpeed;

    [Header("References")]
    public Transform Model;
    public Transform Model2;

    private Rigidbody2D rb;
    private bool isGrounded => Physics2D.Raycast(transform.position, Vector2.down, GroundedCheckRayLenght, GroundLayerMask).collider != null;
    private bool isFlying = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);

        if (isFlying)
        {
            transform.rotation = Quaternion.Euler(0,0, rb.velocity.y);

            if (Input.GetMouseButton(0))
            {
                rb.gravityScale = -FlyingGravity;
            }
            else
            {
                rb.gravityScale = FlyingGravity;
            }
            return;
        }

        if(isGrounded)
        {
            Vector3 modelRotation = Model.rotation.eulerAngles;
            modelRotation.z -= modelRotation.z % 180;
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

    public void SwitchToFlyingMode()
    {
        isFlying = true;
        rb.constraints = RigidbodyConstraints2D.None;
        rb.gravityScale = FlyingGravity;
        Model2.gameObject.SetActive(true);
        Model.gameObject.SetActive(false);
    }

    public void SwitchToRunningMode()
    {
        isFlying = false;
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        rb.gravityScale = 2f;
        Model2.gameObject.SetActive(false);
        Model.gameObject.SetActive(true);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3.down * GroundedCheckRayLenght));
    }
}