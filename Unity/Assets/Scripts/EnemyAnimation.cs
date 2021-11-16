using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public static EnemyAnimation instance;
    Animator enemyAnimator;
    public GameObject enemy;
    new Rigidbody2D rigidbody2D;
    bool isFacingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        enemyAnimator = GetComponent<Animator>();
        enemy = gameObject;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = Vector2.zero;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            UnfreezeX();
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (isFacingRight)
                {
                    FlipPlayer();
                }
                movement.x = (transform.right * Time.deltaTime * -10).x;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                if (!isFacingRight)
                {
                    FlipPlayer();
                }
                movement.x = (transform.right * Time.deltaTime * 10).x;
            }
            if (CheckAnimationPlayingAndTransitioning("Run"))
            {
                enemyAnimator.SetFloat("Speed", 0.1f);
            }

            movement = movement + (Vector2)(transform.position);
            rigidbody2D.MovePosition(movement);
        }
        else
        {
            enemyAnimator.SetFloat("Speed", 0f);
            FreezePosition();
        }
    }

    bool CheckAnimationPlayingAndTransitioning(string animationName) => !enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName(animationName) && !enemyAnimator.IsInTransition(0);

    void FlipPlayer()
    {
        isFacingRight = !isFacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void UnfreezeX()
    {
        rigidbody2D.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
    }

    void FreezePosition()
    {
        rigidbody2D.constraints = ~RigidbodyConstraints2D.FreezeRotation;
    }
}
