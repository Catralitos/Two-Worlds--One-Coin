using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace GGJBoss{
    public class DashAirState : BehaviourState
    {
        public float t = 0;
        float currentHorizontalVelocity;
        Vector3 player;
        string direction;

        bool hitCeilingAlready;
        bool onAir;
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
                target.rb.velocity = Vector2.up*target.jumpForce;
                onAir = true;
            }

             public override void StateUpdate()
            {
                if(target.ceilingHit && !hitCeilingAlready){
                    hitCeilingAlready = true;
                    target.rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                    target.rb.velocity = new Vector2(currentHorizontalVelocity*target.dashSpeed, 0);
                }
                
                //OTHER JUMP
                //target.rb.velocity = new Vector2(currentHorizontalVelocity,10);
                t += Time.deltaTime;

                if(target.wallHit){
                      Debug.Log("ON WALL HIT");
                    //target.currentHealth -= target.hitDamage;
                }

                RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector2.down,20,target.playerMask);

                if(hit.collider != null || target.wallHit)
                {
                    Debug.Log("ON IF");
                    target.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                    target.rb.velocity = Vector2.zero;
                    if(target.grounded)
                        SetState(IdleState.Create(target));
                }
            }

            public static DashAirState Create(Behaviour target)
            {
                return BehaviourState.Create<DashAirState>(target);
            }
    }
}
