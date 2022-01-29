using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GGJBoss{
    public class IdleState : BehaviourState
    {
        float t = 0;

            public override void StateStart(){
            // target.animator.SetTrigger("idle");
                base.StateStart();
                t = 0;
                target.rb.velocity = Vector2.zero;

                if(target.numJumps == 3){
                    target.numJumps = 0;
                    SetState(ShootState.Create(target));
                } 
            }

            public override void StateUpdate()
            {
                t += Time.deltaTime;
                //TODO
                //textField.text = $"Ping {string.Format("{0:0.00}", t)}";
                //play animation

                if (t > target.TimeBetweenStates)
                {
                    if(target.startDash){
                        SetState(DashState.Create(target));
                    } else{
                        SetState(JumpState.Create(target));
                    }
                }
            }

            public static IdleState Create(Behaviour target)
            {
                return BehaviourState.Create<IdleState>(target);
            }
    }

}