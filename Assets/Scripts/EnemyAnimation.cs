using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Enemy Collider: " + other.gameObject.tag);
        if (other.gameObject.tag == "Attack")
        {
            animator.SetTrigger("Damage");
        }
    }
}
