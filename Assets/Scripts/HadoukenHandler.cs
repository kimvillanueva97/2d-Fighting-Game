using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HadoukenHandler : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    Animator animator;
    bool hit = false;
    float thrust = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (!hit) rigidbody2D.AddForce(transform.right * thrust);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.tag == "PWeapon" && other.gameObject.tag == "Enemy")
        {
            Hit();
        }
        else if (gameObject.tag == "EWeapon" && other.gameObject.tag == "Player")
        {
            Hit();
        }
    }

    void Hit()
    {
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezePosition;
        hit = true;
        animator.SetBool("Hit", true);
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
