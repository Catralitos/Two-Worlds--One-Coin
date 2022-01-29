using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace GGJBoss{
    public class JumpState : BehaviourState
    {
        float t = 0;
        Vector3 player;

        float currentHorizontalVelocity;

        float maxHeight = 1.0f;
            
            public override void StateStart(){
                base.StateStart();
                player = PlayerEntity.Instance.gameObject.transform.position;
                if(player.x < transform.position.x)
                    currentHorizontalVelocity = -target.horizontalVelocity;
                else
                    currentHorizontalVelocity = target.horizontalVelocity;

                //target.animator.SetTrigger("jump");
                //target.rb.AddForce((Vector2.up + Vector2.right*player.x).normalized*target.jumpForce);


                target.rb.velocity = Vector2.up*target.jumpForce;

            }
            public override void StateUpdate()
            {
                target.rb.velocity = new Vector2(currentHorizontalVelocity,target.rb.velocity.y);
                //target.rb.velocity = new Vector2(currentHorizontalVelocity,10);
                t += Time.deltaTime;
                
                if (target.grounded && t >= 1 )
                {
                    target.numJumps++;
                    SetState(IdleState.Create(target));
                }
            }

            public static JumpState Create(Behaviour target)
            {
                return BehaviourState.Create<JumpState>(target);
            }
    }

}