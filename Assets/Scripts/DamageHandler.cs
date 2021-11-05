using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageHandler : MonoBehaviour
{
    Animator animator;
    [SerializeField] GameObject Health;
    [SerializeField] Image HealthBackground;
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
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") || animator.GetCurrentAnimatorStateInfo(0).IsName("Block"))
                {
                    animator.Play("Block");
                    DamageTaken(3f);
                    return;
                }
                animator.Play("Damage");
                DamageTaken(10f);
            }
        }
        else
        {
            if (other.gameObject.tag == "EWeapon")
            {
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") || animator.GetCurrentAnimatorStateInfo(0).IsName("Block"))
                {
                    animator.Play("Block");
                    DamageTaken(3f);
                    return;
                }
                animator.Play("Damage");
                DamageTaken(10f);
            }
        }
    }

    void DamageTaken(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) currentHealth = 100;
    }

    void Update()
    {
        HealthBar.value = Mathf.Lerp(HealthBar.value, currentHealth, 2f * Time.deltaTime);
        if (HealthBackground)
        {
            HealthBackground.fillAmount = currentHealth / 100;
        }
    }
}
