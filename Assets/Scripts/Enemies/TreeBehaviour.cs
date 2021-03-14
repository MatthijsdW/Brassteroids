using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBehaviour : EnemyBehaviour
{
    public float maxTorque;

    void Start()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        rigidbody.centerOfMass = Vector2.zero;
        rigidbody.AddTorque(Random.Range(-maxTorque, maxTorque));
    }

    public override void ApplyEffect(GameObject player) { }

    public override void Destroy()
    {
        Destroy(transform.parent.gameObject);
    }
}
