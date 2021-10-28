using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HadoukenHandler : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    float thrust = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rigidbody2D.AddForce(transform.right * thrust);
    }
}
