using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipMovement : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;

    private Vector2 moveValue;
    private new Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveValue != null)
        {
            rigidbody.AddRelativeForce(moveSpeed * moveValue.y * Time.deltaTime * Vector2.up);
            rigidbody.AddTorque(turnSpeed * -moveValue.x * Time.deltaTime);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveValue = context.ReadValue<Vector2>();
    }
}
