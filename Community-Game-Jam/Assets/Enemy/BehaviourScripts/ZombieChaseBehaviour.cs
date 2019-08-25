﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieChaseBehaviour : StateMachineBehaviour
{
    private Transform playerPos;
    public float speed;
    public float attackDistance;
    public ParticleSystem explode;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 direction = new Vector2(playerPos.transform.position.x - animator.transform.position.x, 
        playerPos.transform.position.y - animator.transform.position.y);

        animator.transform.right = direction;
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, playerPos.position, speed * Time.deltaTime);

        if (Vector2.Distance(animator.transform.position, playerPos.transform.position) < attackDistance) 
        {
           Instantiate(explode, animator.transform.position, explode.transform.rotation);
           Destroy(animator.gameObject);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}