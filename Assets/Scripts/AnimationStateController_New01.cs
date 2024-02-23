using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController_New01 : MonoBehaviour
{
    Animator animator;
    float velocityZ = 0.0f;
    float velocityX = 0.0f;
    public float acceleration = 1.0f;
    public float deceleration = 1.0f;
    public float maximumWalkVelocity = 0.5f;
    public float maximumRunVelocity = 2f;
    public float maximumSprintVelocity = 4f;
    public float maximumBackwardsVelocity = -2f;

    //increase performance
    int VelocityXHash;
    int VelocityZHash;

    // Start is called before the first frame update
    void Start()
    {
        //searcb the gameobject this script is attached to and get the animator component
        animator = GetComponent<Animator>();

        //increase performance
        VelocityXHash = Animator.StringToHash("VelocityX");
        VelocityZHash = Animator.StringToHash("VelocityZ");
    }

    //handle acceleration and deceleration
    void ChangeVelocity(bool forwardPressed, bool leftPressed, bool rightPressed,bool backwardPressed,bool walkPressed, bool runPressed, float currentMaxVelocity)
    {
        //if player press forward, increase or decrease velocity in z direction
        if (forwardPressed && velocityZ < currentMaxVelocity && !walkPressed )
        {
            velocityZ += Time.deltaTime * acceleration;
        }
        //increase velocity in the left direction
        if (leftPressed && velocityX > -currentMaxVelocity && !walkPressed )
        {
            velocityX -= Time.deltaTime * acceleration;
        }
        //increase velocity in the right direction
        if (rightPressed && velocityX < currentMaxVelocity && !walkPressed)
        {
            velocityX += Time.deltaTime * acceleration;
        }
        //increase velocity in the back direction
        if (backwardPressed && velocityZ > maximumBackwardsVelocity && !walkPressed)
        {
            velocityZ -= Time.deltaTime * acceleration;
        }

        //decrease velocityZ if back is not pressed and velocityZ > 0
        if (!forwardPressed && !backwardPressed && velocityZ > 0.0f)
        {
            velocityZ -= Time.deltaTime * deceleration;
        }
        //decrease velocityZ if back is not pressed and velocityZ < 0
        if (!forwardPressed && !backwardPressed && velocityZ < 0.0f)
        {
            velocityZ += Time.deltaTime * deceleration;
        }

        //decrease velocityX if left is not pressed and velocityX < 0
        if ((!leftPressed && !rightPressed && velocityX < 0.0f))
        {
            velocityX += Time.deltaTime * deceleration;
        }
        //decrease velocityX if right is not pressed and velocityX > 0
        if ((!leftPressed && !rightPressed && velocityX > 0.0f))
        {
            velocityX -= Time.deltaTime * deceleration;
        }
    }

    //handle reset and locking of velocity
    void LockOrResetVelocity(bool forwardPressed, bool leftPressed, bool rightPressed, bool backwardPressed, bool walkPressed, bool runPressed, float currentMaxVelocity)
    {
        //reset velocityZ
        if (!forwardPressed && !backwardPressed && velocityZ != 0.0f && (velocityZ > -0.05f && velocityZ < 0.05f))
        {
            velocityZ = 0.0f;
        }

        //reset velocityX
        if (!leftPressed && !rightPressed && velocityX != 0.0f && (velocityX > -0.5f && velocityX < 0.5f))
        {
            velocityX = 0.0f;
        }

        //lockforward
        if (forwardPressed && runPressed && velocityZ > currentMaxVelocity)
        {
            velocityZ = currentMaxVelocity;
            //deceleration to maximum run speed 2f     
        }
        else if (forwardPressed && velocityZ > currentMaxVelocity)
        {
            velocityZ -= Time.deltaTime * deceleration;
            // round to the currentMaxVelocity if within offset
            if (velocityZ < currentMaxVelocity && velocityZ < (currentMaxVelocity + 2f))
            {
                velocityZ = currentMaxVelocity;
            }
            // round to the currentMaxVelocity if within offset 
        }
        else if (forwardPressed && velocityZ > currentMaxVelocity && velocityZ > (currentMaxVelocity - 2f))
        {
            velocityZ = currentMaxVelocity;
        }
        //lockright
        if (rightPressed && runPressed && velocityX > currentMaxVelocity)
        {
            velocityX = currentMaxVelocity;
            //deceleration to maximum run speed 2f     
        }
        else
        {
            if (rightPressed && velocityX > currentMaxVelocity)
            {
                velocityX -= Time.deltaTime * deceleration;
                // round to the currentMaxVelocity if within offset
                if (velocityX < currentMaxVelocity && velocityX < (currentMaxVelocity + 2f))
                {
                    velocityX = currentMaxVelocity;
                }
                // round to the currentMaxVelocity if within offset 
            }
            else if (rightPressed && velocityX > currentMaxVelocity && velocityX > (currentMaxVelocity - 2f))
            {
                velocityX = currentMaxVelocity;
            }

            if(rightPressed && backwardPressed && runPressed && velocityX > -maximumBackwardsVelocity)
            {
                velocityX = -maximumBackwardsVelocity;
            }
        }

        //lockleft
        if (leftPressed && runPressed && velocityX < -currentMaxVelocity)
        {
            velocityX = -currentMaxVelocity;
            //deceleration to maximum run speed 2f     
        }
        else
        {
            if (leftPressed && velocityX < -currentMaxVelocity)
            {
                velocityX += Time.deltaTime * deceleration;
                // round to the currentMaxVelocity if within offset
                if (velocityX > -currentMaxVelocity && velocityX > (-currentMaxVelocity - 2f))
                {
                    velocityX = -currentMaxVelocity;
                }
                // round to the currentMaxVelocity if within offset 
            }
            else if (leftPressed && velocityX < -currentMaxVelocity && velocityX < (-currentMaxVelocity + 2f))
            {
                velocityX = -currentMaxVelocity;
            }
            if (leftPressed && backwardPressed && runPressed && velocityX < maximumBackwardsVelocity)
            {
                velocityX = maximumBackwardsVelocity;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        //input will be true if the player is pressing on the passed in key parameter
        //get key input from player
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool leftPressed = Input.GetKey(KeyCode.A);
        bool rightPressed = Input.GetKey(KeyCode.D);
        bool backwardPressed = Input.GetKey(KeyCode.S);
        bool walkPressed = Input.GetKey(KeyCode.LeftControl);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);
        bool jumpPressed=Input.GetKey(KeyCode.Space);

        // set current maxVelocity
        float currentMaxVelocity = runPressed ? maximumSprintVelocity : maximumRunVelocity;
        float currentMaxVelocityWalk = walkPressed ? maximumWalkVelocity : maximumRunVelocity;

        //handle change in velocity
        ChangeVelocity(forwardPressed, leftPressed, rightPressed, backwardPressed, walkPressed, runPressed, currentMaxVelocity);
        LockOrResetVelocity(forwardPressed, leftPressed, rightPressed, backwardPressed, walkPressed, runPressed, currentMaxVelocity);



        //Set the parameters to our local varible values
        animator.SetFloat(VelocityZHash, velocityZ);
        animator.SetFloat(VelocityXHash, velocityX);
    }
}
