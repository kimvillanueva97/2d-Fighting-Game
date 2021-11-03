using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public static PlayerAnimation instance;
    Animator playerAnimator;
    public GameObject player;
    [SerializeField] public GameObject hadouken;
    new Rigidbody2D rigidbody2D;
    bool isFacingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        playerAnimator = GetComponent<Animator>();
        player = gameObject;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = Vector2.zero;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            UnfreezeX();
            if (Input.GetKey(KeyCode.A))
            {
                if (isFacingRight)
                {
                    FlipPlayer();
                }
                movement.x = (transform.right * -10 * Time.deltaTime).x;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                if (!isFacingRight)
                {
                    FlipPlayer();
                }
                movement.x = (transform.right * 10 * Time.deltaTime).x;
            }
            if (!CheckAnimationPlayingAndTransitioning("Run"))
            {
                playerAnimator.SetFloat("Speed", 0.1f);
            }

            movement = movement + (Vector2)(transform.position);
            rigidbody2D.MovePosition(movement);
        }
        else
        {
            playerAnimator.SetFloat("Speed", 0f);
            FreezePosition();
        }
    }

    bool CheckAnimationPlayingAndTransitioning(string animationName) => playerAnimator.GetCurrentAnimatorStateInfo(0).IsName(animationName) && !playerAnimator.IsInTransition(0);

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
