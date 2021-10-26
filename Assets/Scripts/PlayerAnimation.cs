using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator playerAnimator;
    bool isFacingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CheckAnimationPlaying("Attack"))
            {
                playerAnimator.SetTrigger("Attack");
            }
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.A))
            {
                if (isFacingRight)
                {
                    FlipPlayer();
                }
            }
            else if (Input.GetKey(KeyCode.D))
            {
                if (!isFacingRight)
                {
                    FlipPlayer();
                }
            }
            if (CheckAnimationPlaying("Run"))
            {
                playerAnimator.SetFloat("Speed", 0.1f);
            }
        }
        else
        {
            playerAnimator.SetFloat("Speed", 0f);
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log(other.gameObject.tag + "Player Side");
            playerAnimator.SetTrigger("Damage");
        }
    }

    bool CheckAnimationPlaying(string animationName) => !playerAnimator.GetCurrentAnimatorStateInfo(0).IsName(animationName) && !playerAnimator.IsInTransition(0);

    protected void FlipPlayer()
    {
        isFacingRight = !isFacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
