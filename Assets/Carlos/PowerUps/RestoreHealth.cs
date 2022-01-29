using Player;

namespace PowerUps
{
    public class RestoreHealth : PowerUp
    {
        protected override void TriggerEffect()
        {
            PlayerEntity.Instance.PowerUps.healthsToTrigger++;
        }
    }
}