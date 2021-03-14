using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Axe : Equipment
{
    private bool swinging = false;
    private bool mirror = false;
    public float swingSpeed;
    public float damage;
    List<Transform> enemiesHit;

    private void Start()
    {
        enemiesHit = new List<Transform>();
    }

    void Update()
    {
        if (!swinging)
            return;

        if (!mirror)
        {
            if (transform.localEulerAngles.z > 180)
            {
                transform.localEulerAngles = new Vector3(0, 180, 0);
                swinging = false;
                mirror = true;
                enemiesHit.Clear();
            }
            else
            {
                transform.Rotate(Vector3.forward, swingSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (transform.localEulerAngles.z > 180)
            {
                transform.localEulerAngles = new Vector3(0, 0, 0);
                swinging = false;
                mirror = false;
                enemiesHit.Clear();
            }
            else
            {
                transform.Rotate(Vector3.forward, swingSpeed * Time.deltaTime);
            }
        }
    }

    public override void UseEquipment()
    {
        swinging = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!swinging || collision.tag != "Enemy")
            return;

        Transform topLevelParent = collision.transform;
        while (topLevelParent.parent != null)
            topLevelParent = topLevelParent.parent;

        //Can't hit the same enemy twice in a single swing.
        if (!enemiesHit.Contains(topLevelParent))
        {
            topLevelParent.GetComponent<EnemyHealth>().currentHealth -= damage;
            enemiesHit.Add(topLevelParent);
        }
    }
}
