using Player;

namespace PowerUps
{
    public class AddShield : PowerUp
    {
        protected override void TriggerEffect()
        {
            PlayerEntity.Instance.PowerUps.shieldsToTrigger++;
        }
    }
}