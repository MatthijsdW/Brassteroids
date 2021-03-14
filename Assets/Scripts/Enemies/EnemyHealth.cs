using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;

    private Transform healthBar;
    private Transform healthBarBackground;

    private Transform enemy;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar = transform.Find("HealthBar");
        healthBarBackground = transform.Find("HealthBarBackground");

        enemy = transform.GetComponentInChildren<Rigidbody2D>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.position = enemy.position + new Vector3(-0.1f, 1.4f, 0.2f);
        healthBarBackground.position = enemy.position + new Vector3(-0.1f, 1.4f, 0.3f);

        healthBar.localScale = new Vector3(currentHealth / maxHealth, 1, 1);

        if (currentHealth <= 0)
        {
            GetComponentInChildren<EnemyBehaviour>().Destroy();
        }
    }
}
