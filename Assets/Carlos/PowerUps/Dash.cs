using Player;

namespace PowerUps
{
    public class Dash : PowerUp
    {
        protected override void TriggerEffect()
        {
            PlayerEntity.Instance.PowerUps.dashesToTrigger++;
        }
    }
}