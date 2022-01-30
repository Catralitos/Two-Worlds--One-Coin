using Player;
using UnityEngine;

namespace Boss
{
    public class DashState : BossState
    {
        public float t = 0;
        float currentHorizontalVelocity;
        Vector3 player;
        public string direction;
        private bool hitWall;

        public override void StateStart()
        {
            base.StateStart();
            t = 0;

            target.animator.Play("Base Layer.IntroDash", 0, 0.0f);

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

            target.checkDirection();
        }

        public override void StateUpdate()
        {
            t += Time.deltaTime;

            if (t < 2)
                return;

            target.rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            target.animator.Play("Base Layer.Dash", 0, 0.0f);
            target.rb.velocity = new Vector2(currentHorizontalVelocity * target.dashSpeed, target.rb.velocity.y);

            if ((target.wallHitRight && direction == "right") || (target.wallHitLeft && direction == "left"))
            {
                target.currentHealth -= target.hitDamage;
                //   target.healthBar.value = target.currentHealth;
                target.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                target.rb.velocity = Vector2.zero;
                target.animator.Play("Base Layer.ExitDash", 0, 0.0f);
                SetState(DashAirState.Create(target));
            }
        }

        public static DashState Create(Boss target)
        {
            return BossState.Create<DashState>(target);
        }
    }
}