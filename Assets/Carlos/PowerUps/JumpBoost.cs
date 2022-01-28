using Player;

namespace PowerUps
{
    public class JumpBoost : PowerUp
    {
        public float jumpBoost;

        public override void TriggerEffect()
        {
            base.TriggerEffect();
            PlayerEntity.Instance.Movement.currentJumpPower = PlayerEntity.Instance.Movement.jumpPower * jumpBoost;
        }

        protected override void StopEffect()
        {
            PlayerEntity.Instance.Movement.currentJumpPower = PlayerEntity.Instance.Movement.jumpPower;
        }
    }
}