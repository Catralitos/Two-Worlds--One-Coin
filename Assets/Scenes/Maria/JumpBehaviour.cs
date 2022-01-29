using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class JumpBehaviour : StateMachineBehaviour
{
    public float timer;
    public float maxTime;
    public float minTime;

    private Transform playerPos;
    public float speed;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = PlayerEntity.Instance.gameObject.transform;
        timer = maxTime;//Random.Range(minTime, maxTime);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= minTime)
            animator.SetTrigger("idle");
        else
            timer -= Time.deltaTime;

       // Vector2 target = new Vector2(playerPos.position.x, animator.transform.position.y);
        //animator.transform.position = Vector2.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);

        //animator.transform.Translate(1.0f,0.0f,0.0f);
    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}
