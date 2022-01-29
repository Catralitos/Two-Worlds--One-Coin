using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace GGJBoss{
    public class DashState : BehaviourState
    {
        public float t = 0;
        float currentHorizontalVelocity;
        Vector3 player;
        string direction;
        private bool hitWall;
         public override void StateStart(){
                base.StateStart();
                t = 0;

                player = PlayerEntity.Instance.gameObject.transform.position;
                if(player.x < transform.position.x){
                    currentHorizontalVelocity = -target.horizontalVelocity;
                    direction = "left";
                }else{
                    currentHorizontalVelocity = target.horizontalVelocity;
                    direction = "right";
                }
            }

            public override void StateUpdate()
            {
                target.rb.velocity = new Vector2(currentHorizontalVelocity*target.dashSpeed,target.rb.velocity.y);
               
                t += Time.deltaTime;


                if(target.wallHit)
                {
                    //target.currentHealth -= target.hitDamage;
                    Debug.Log("ENTERING WALL HIT ENTER");
                    target.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                    target.rb.velocity = Vector2.zero;
                    SetState(DashAirState.Create(target));
                }
            }

            public static DashState Create(Behaviour target)
            {
                return BehaviourState.Create<DashState>(target);
            }

            

            
    }

}