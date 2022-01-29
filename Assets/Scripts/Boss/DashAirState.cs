using Player;
using UnityEngine;

namespace Boss
{
    public class DashAirState : BossState
    {
        public float t = 0;
        float currentHorizontalVelocity;
        Vector3 player;
        public string direction;

        bool onAir;
        private bool falling;


        public override void StateStart()
        {
            base.StateStart();
            t = 0;

            player = PlayerEntity.Instance.gameObject.transform.position;
            if (player.x < transform.position.x || target.wallHitRight)
            {
                currentHorizontalVelocity = -target.horizontalVelocity;
                direction = "left";
            }
            else
            {
                currentHorizontalVelocity = target.horizontalVelocity;
                direction = "right";
            }
        }

        public override void StateUpdate()
        {
            t += Time.deltaTime;

            if (t < 1)
                return;

            if (!onAir)
            {
                onAir = true;
                target.rb.velocity = Vector2.up * target.ceilingJump;
            }

            if (falling && target.grounded)
                SetState(IdleState.Create(target));

            if (falling)
                return;

            if (target.ceilingHit)
            {
                target.rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                target.rb.velocity = new Vector2(currentHorizontalVelocity * target.dashSpeed, target.rb.velocity.y);
            }

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 20, target.playerMask);

            if (hit.collider != null || (target.wallHitRight && direction == "right") ||
                (target.wallHitLeft && direction == "left"))
            {
                if (hit.collider == null)
                {
                    target.currentHealth -= target.hitDamage;
            //        target.healthBar.value = target.currentHealth;
                }

                falling = true;

                Debug.Log("ON IF");
                target.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                target.rb.velocity = Vector2.zero;
            }
        }

        public static DashAirState Create(Boss target)
        {
            return BossState.Create<DashAirState>(target);
        }
    }
}