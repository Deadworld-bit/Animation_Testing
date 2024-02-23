using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingForwardsHash;
    int isWalkingLeftHash;
    int isWalkingRightHash;
    int isWalkingBackwardsHash;
    int isWalkingForwardsRightHash;
    int isWalkingForwardsLeftHash;
    int isWalkingBackwardsRightHash;
    int isWalkingBackwardsLeftHash;

    int isRunningForwardsHash;
    int isRunningForwardsRightHash;
    int isRunningForwardsLeftHash;

    int isJumpingHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log(animator);
        isWalkingForwardsHash = Animator.StringToHash("isWalkingForwards");
        isWalkingLeftHash = Animator.StringToHash("isWalkingLeft");
        isWalkingRightHash = Animator.StringToHash("isWalkingRight");
        isWalkingBackwardsHash = Animator.StringToHash("isWalkingBackwards");
        isWalkingForwardsLeftHash = Animator.StringToHash("isWalkingForwardsLeft");
        isWalkingForwardsRightHash = Animator.StringToHash("isWalkingForwardsRight");
        isWalkingBackwardsLeftHash = Animator.StringToHash("isWalkingBackwardsLeft");
        isWalkingBackwardsRightHash = Animator.StringToHash("isWalkingBackwardsRight");

        isRunningForwardsHash = Animator.StringToHash("isRunningForwards");
        isRunningForwardsLeftHash = Animator.StringToHash("isRunningForwardsLeft");
        isRunningForwardsRightHash = Animator.StringToHash("isRunningForwardsRight");

        isJumpingHash = Animator.StringToHash("isJumping");
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalkingForwards = animator.GetBool(isWalkingForwardsHash);
        bool isWalkingForwardsRight = animator.GetBool(isWalkingForwardsRightHash);
        bool isWalkingForwardsLeft = animator.GetBool(isWalkingForwardsLeftHash);
        bool isWalkingLeft = animator.GetBool(isWalkingLeftHash);
        bool isWalkingRight = animator.GetBool(isWalkingRightHash);
        bool isWalkingBackwards = animator.GetBool(isWalkingBackwardsHash);
        bool isWalkingBackwardsRight = animator.GetBool(isWalkingBackwardsRightHash);
        bool isWalkingBackwardsLeft = animator.GetBool(isWalkingBackwardsLeftHash);

        bool isRunningForwards = animator.GetBool(isRunningForwardsHash);
        bool isRunningForwardsLeft = animator.GetBool(isRunningForwardsLeftHash);
        bool isRunningForwardsRight = animator.GetBool(isRunningForwardsRightHash);

        bool isJumping = animator.GetBool(isJumpingHash);

        bool forwardsPressed = Input.GetKey("w");
        bool leftPressed = Input.GetKey("a");
        bool rightPressed = Input.GetKey("d");
        bool backwardsPressed = Input.GetKey("s");
        bool runPressed = Input.GetKey("left shift");
        bool jumpPressed = Input.GetKey("space");

        //if the player press w
        if (!isWalkingForwards && forwardsPressed)
        {
            //then set the isRunning boolean to be true
            animator.SetBool(isWalkingForwardsHash, true);
        }
        if(isWalkingForwards && !forwardsPressed)
        {
            //then set the isRunning boolean to be false
            animator.SetBool(isWalkingForwardsHash, false);
        }

        // if player press w and left shift
        if(!isRunningForwards && (forwardsPressed && runPressed))
        {
            //then set the isRunning boolean to be true
            animator.SetBool(isRunningForwardsHash, true);
        }
        //if player stops running or stops walking
        if(!forwardsPressed || !runPressed)
        {
            // then set the isRunning boolean to be false
            animator.SetBool(isRunningForwardsHash, false);
        }

        // if player press w, a and left shift
        if (!isRunningForwardsLeft && (forwardsPressed && leftPressed && runPressed))
        {
            //then set the isRunning boolean to be true
            animator.SetBool(isRunningForwardsLeftHash, true);
        }
        //if player stops running or stops walking
        if (!forwardsPressed || !leftPressed || !runPressed)
        {
            // then set the isRunning boolean to be false
            animator.SetBool(isRunningForwardsLeftHash, false);
        }

        // if player press w, d and left shift
        if (!isRunningForwardsRight && (forwardsPressed && rightPressed && runPressed))
        {
            //then set the isRunning boolean to be true
            animator.SetBool(isRunningForwardsRightHash, true);
        }
        //if player stops running or stops walking
        if (!forwardsPressed || !rightPressed || !runPressed)
        {
            // then set the isRunning boolean to be false
            animator.SetBool(isRunningForwardsRightHash, false);
        }

        //if the player press w & a
        if (!isWalkingForwardsLeft && (leftPressed && forwardsPressed))
        {
            //then set the isRunning boolean to be true
            animator.SetBool(isWalkingForwardsLeftHash, true);
        }
        if (isWalkingForwardsLeft && (!forwardsPressed || !leftPressed))
        {
            //then set the isRunning boolean to be false
            animator.SetBool(isWalkingForwardsLeftHash, false);
        }

        //if the player press w & d
        if (!isWalkingForwardsRight && (rightPressed && forwardsPressed))
        {
            //then set the isRunning boolean to be true
            animator.SetBool(isWalkingForwardsRightHash, true);
        }
        if (isWalkingForwardsRight && (!forwardsPressed || !rightPressed))
        {
            //then set the isRunning boolean to be false
            animator.SetBool(isWalkingForwardsRightHash, false);
        }

        //if the player press a
        if (!isWalkingLeft && leftPressed)
        {
            //then set the isRunning boolean to be true
            animator.SetBool(isWalkingLeftHash, true);
        }
        if (isWalkingLeft && !leftPressed)
        {
            //then set the isRunning boolean to be false
            animator.SetBool(isWalkingLeftHash, false);
        }

        //if the player press d
        if (!isWalkingRight && rightPressed)
        {
            //then set the isRunning boolean to be true
            animator.SetBool(isWalkingRightHash, true);
        }
        if (isWalkingRight && !rightPressed)
        {
            //then set the isRunning boolean to be false
            animator.SetBool(isWalkingRightHash, false);
        }

        //if the player press s
        if (!isWalkingBackwards && backwardsPressed)
        {
            //then set the isRunning boolean to be true
            animator.SetBool(isWalkingBackwardsHash, true);
        }
        if (isWalkingBackwards && !backwardsPressed)
        {
            //then set the isRunning boolean to be false
            animator.SetBool(isWalkingBackwardsHash, false);
        }

        //if the player press s & a
        if (!isWalkingBackwardsLeft && (leftPressed && backwardsPressed))
        {
            //then set the isRunning boolean to be true
            animator.SetBool(isWalkingBackwardsLeftHash, true);
        }
        if (isWalkingBackwardsLeft && (!backwardsPressed || !leftPressed))
        {
            //then set the isRunning boolean to be false
            animator.SetBool(isWalkingBackwardsLeftHash, false);
        }

        //if the player press s & d
        if (!isWalkingBackwardsRight && (rightPressed && backwardsPressed))
        {
            //then set the isRunning boolean to be true
            animator.SetBool(isWalkingBackwardsRightHash, true);
        }
        if (isWalkingBackwardsRight && (!backwardsPressed || !rightPressed))
        {
            //then set the isRunning boolean to be false
            animator.SetBool(isWalkingBackwardsRightHash, false);
        }

        //if the player press space
        if (!isJumping && jumpPressed)
        {
            //then set the isRunning boolean to be true
            animator.SetBool(isJumpingHash, true);
        }
        if (isJumping && !jumpPressed)
        {
            //then set the isRunning boolean to be false
            animator.SetBool(isJumpingHash, false);
        }
    }
}
