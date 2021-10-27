using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    Animator playerAnimator;
    GameObject player;
    bool isFacingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        player = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (CheckAnimationPlayingAndTransitioning("Attack"))
            {
                playerAnimator.SetTrigger("Attack");
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (isFacingRight)
                {
                    FlipPlayer();
                }
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                if (!isFacingRight)
                {
                    FlipPlayer();
                }
            }
            if (CheckAnimationPlayingAndTransitioning("Run"))
            {
                playerAnimator.SetFloat("Speed", 0.1f);
            }
        }
        else
        {
            playerAnimator.SetFloat("Speed", 0f);
        }
    }

    bool CheckAnimationPlayingAndTransitioning(string animationName) => !playerAnimator.GetCurrentAnimatorStateInfo(0).IsName(animationName) && !playerAnimator.IsInTransition(0);

    void FlipPlayer()
    {
        isFacingRight = !isFacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
