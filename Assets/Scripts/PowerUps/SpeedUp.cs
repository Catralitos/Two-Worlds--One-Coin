using Player;

namespace PowerUps
{
    public class SpeedUp : PowerUp
    {
        protected override void TriggerEffect()
        {
            PlayerEntity.Instance.PowerUps.speedsToTrigger++;
        }

    }
}