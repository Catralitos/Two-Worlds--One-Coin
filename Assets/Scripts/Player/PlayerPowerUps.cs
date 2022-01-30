using UnityEngine;

namespace Player
{
    public class PlayerPowerUps : MonoBehaviour
    {
        public int healthBoost;
        
        public int shields;
        public int maxShields;
        
        public float dashTime;
        public float maxDashTime;
        public float jumpTime;
        public float maxJumpTime;
        public float speedTime;
        public float maxSpeedTime;

        public float jumpBoost;
        public float speedBoost;

        [HideInInspector] public int healthsToTrigger;
        [HideInInspector] public int shieldsToTrigger;
        [HideInInspector] public int dashesToTrigger;
        [HideInInspector] public int jumpsToTrigger;
        [HideInInspector] public int speedsToTrigger;

        [HideInInspector] public float dashTimeRemaining;
        [HideInInspector] public float jumpBoostRemaining;
        [HideInInspector] public float speedBoostRemaining;

        private bool _inSurrealWorld;

        public void SwitchToNightmare()
        {
            _inSurrealWorld = true;

            for (int i = 0; i < healthsToTrigger; i++)
            {
                PlayerEntity.Instance.Health.RestoreHealth(healthBoost);
            }

            for (int i = 0; i < shieldsToTrigger; i++)
            {
                PlayerEntity.Instance.Health.AddShields(shields);
            }

            for (int i = 0; i < dashesToTrigger; i++)
            {
                dashTimeRemaining = Mathf.Clamp(dashTimeRemaining + dashTime, 0, maxDashTime);
            }

            for (int i = 0; i < jumpsToTrigger; i++)
            {
                jumpBoostRemaining = Mathf.Clamp(jumpBoostRemaining + jumpTime, 0, maxJumpTime);
            }

            for (int i = 0; i < speedsToTrigger; i++)
            {
                speedBoostRemaining = Mathf.Clamp(speedBoostRemaining + speedTime, 0, maxSpeedTime);
            }

            healthsToTrigger = 0;
            shieldsToTrigger = 0;
            dashesToTrigger = 0;
            jumpsToTrigger = 0;
            speedsToTrigger = 0;
        }

        private void Update()
        {
            PlayerMovement movement = PlayerEntity.Instance.Movement;

            if (_inSurrealWorld)
            {
                dashTimeRemaining -= Time.deltaTime;
                jumpBoostRemaining -= Time.deltaTime;
                speedBoostRemaining -= Time.deltaTime;


                movement.canDash = dashTimeRemaining > 0.0f;
                movement.currentJumpPower =
                    jumpBoostRemaining > 0.0f ? movement.jumpPower * jumpBoost : movement.jumpPower;
                movement.currentMoveSpeed =
                    speedBoostRemaining > 0.0f ? movement.moveSpeed * speedBoost : movement.moveSpeed;
            }
            else
            {
               // movement.canDash = false;
                movement.currentJumpPower = movement.jumpPower;
                movement.currentMoveSpeed = movement.moveSpeed;
            }
        }
    }
}