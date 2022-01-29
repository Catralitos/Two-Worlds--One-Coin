using UnityEngine;

namespace Player
{
    public class PlayerPowerUps : MonoBehaviour
    {
        public int healthBoost;
        public int shields;

        public float dashTime;
        public float jumpTime;
        public float speedTime;

        public float jumpBoost;
        public float speedBoost;

        [HideInInspector] public int healthsToTrigger;
        [HideInInspector] public int shieldsToTrigger;
        [HideInInspector] public int dashesToTrigger;
        [HideInInspector] public int jumpsToTrigger;
        [HideInInspector] public int speedsToTrigger;

        private float _dashTimeRemaining;
        private float _jumpBoostRemaining;
        private float _speedBoostRemaining;

        private bool inSurrealWorld;
        public void SwitchToNightmare()
        {
            inSurrealWorld = true;

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
                _dashTimeRemaining = _dashTimeRemaining > 0.0f ? _dashTimeRemaining + dashTime : dashTime;
            }

            for (int i = 0; i < jumpsToTrigger; i++)
            {
                _jumpBoostRemaining = _jumpBoostRemaining > 0.0f ? _jumpBoostRemaining + jumpTime : jumpTime;
            }

            for (int i = 0; i < speedsToTrigger; i++)
            {
                _speedBoostRemaining = _speedBoostRemaining > 0.0f ? _speedBoostRemaining + speedTime : speedTime;
            }

            healthsToTrigger = 0;
            shieldsToTrigger = 0;
            dashesToTrigger = 0;
            jumpsToTrigger = 0;
            speedsToTrigger = 0;
        }

        private void Update()
        {
            if (inSurrealWorld)
            {           //TODO meter aqui um if está no mundo imaginário
                _dashTimeRemaining -= Time.deltaTime;
                _jumpBoostRemaining -= Time.deltaTime;
                _speedBoostRemaining -= Time.deltaTime;
          
            PlayerMovement movement = PlayerEntity.Instance.Movement;

           // movement.canDash = _dashTimeRemaining > 0.0f;
            movement.currentJumpPower =
                _jumpBoostRemaining > 0.0f ? movement.jumpPower * jumpBoost : movement.jumpPower;
            movement.currentMoveSpeed =
                _speedBoostRemaining > 0.0f ? movement.moveSpeed * speedBoost : movement.moveSpeed;

            //meter um else para tirar/pausar boosts e isso durante o mundo real
        }
        }
    }
}