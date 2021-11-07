using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamnzaAnimation : MonoBehaviour
{
    public static RamnzaAnimation instance;
    public GameObject player;
    [SerializeField] GameObject enemy;
    Animator playerAnimator;
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

        FaceDirection();

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            UnfreezeX();
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (!CheckAnimationPlayingAndTransitioning("Damage"))
                {
                    playerAnimator.SetFloat("Speed", -1f);
                }
                movement.x = (transform.right * -1 * Time.deltaTime).x;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                if (!CheckAnimationPlayingAndTransitioning("Damage"))
                {
                    playerAnimator.SetFloat("Speed", 1f);
                }
                movement.x = (transform.right * 1 * Time.deltaTime).x;
            }

            movement = movement + (Vector2)(transform.position);
            rigidbody2D.MovePosition(movement);
        }
        else
        {
            if (playerAnimator.GetFloat("Speed") != 0f)
            {
                playerAnimator.SetFloat("Speed", 0f);
            }
            FreezePosition();
        }
    }

    bool CheckAnimationPlayingAndTransitioning(string animationName) => playerAnimator.GetCurrentAnimatorStateInfo(0).IsName(animationName) && playerAnimator.GetAnimatorTransitionInfo(0).duration > 0;

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

    void FaceDirection()
    {
        float playerPosition = player.transform.position.x;
        float enemyPosition = enemy.transform.position.x;

        float enemyDirection = playerPosition - enemyPosition;

        if (isFacingRight && enemyDirection < 0)
        {
            FlipPlayer();
        }
        else if (!isFacingRight && enemyDirection > 0)
        {
            FlipPlayer();
        }
    }
}
