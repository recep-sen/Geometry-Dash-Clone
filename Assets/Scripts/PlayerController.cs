using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;

    private void Update()
    {
        transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);
    }
}