using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageHandler : MonoBehaviour
{
    Animator animator;
    [SerializeField] GameObject Health;
    Slider HealthBar;
    float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        HealthBar = Health.GetComponent<Slider>();
        currentHealth = HealthBar.value;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.tag == "Enemy")
        {
            if (other.gameObject.tag == "PWeapon")
            {
                animator.SetTrigger("Damage");
                currentHealth -= 10f;
                if (currentHealth <= 0) currentHealth = 100;
                HealthBar.SetValueWithoutNotify(currentHealth);
            }
        }
        else
        {
            if (other.gameObject.tag == "EWeapon")
            {
                animator.SetTrigger("Damage");
                currentHealth -= 10f;
                if (currentHealth <= 0) currentHealth = 100;
                HealthBar.SetValueWithoutNotify(currentHealth);
            }
        }
    }
}
