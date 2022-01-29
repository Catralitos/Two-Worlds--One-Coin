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
        public string direction;
        private bool hitWall;

         public override void StateStart(){
                base.StateStart();
                t = 0;

                player = PlayerEntity.Instance.gameObject.transform.position;
                if(player.x < transform.position.x || target.wallHitRight){
                    currentHorizontalVelocity = -target.horizontalVelocity;
                    direction = "left";
                }else{
                    currentHorizontalVelocity = target.horizontalVelocity;
                    direction = "right";
                }
            }

            public override void StateUpdate()
            {
                t += Time.deltaTime;
                
                if(t < 2)
                    return;

                target.rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                target.rb.velocity = new Vector2(currentHorizontalVelocity*target.dashSpeed,target.rb.velocity.y);
               
                if((target.wallHitRight && direction == "right") || (target.wallHitLeft && direction == "left"))
                {
                    target.currentHealth -= target.hitDamage;
                    target.healthBar.value = target.currentHealth;
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