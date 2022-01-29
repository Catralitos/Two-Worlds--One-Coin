using Player;

namespace PowerUps
{
    public class JumpBoost : PowerUp
    {
        protected override void TriggerEffect()
        {
            PlayerEntity.Instance.PowerUps.jumpsToTrigger++;
        }

    }
}