using Player;

namespace PowerUps
{
    public class SpeedUp : PowerUp
    {
        public float speedBoost;

        public override void TriggerEffect()
        {
            base.TriggerEffect();
            PlayerEntity.Instance.Movement.currentMoveSpeed = PlayerEntity.Instance.Movement.moveSpeed * speedBoost;
        }

        protected override void StopEffect()
        {
            PlayerEntity.Instance.Movement.currentMoveSpeed = PlayerEntity.Instance.Movement.moveSpeed;
        }
    }
}