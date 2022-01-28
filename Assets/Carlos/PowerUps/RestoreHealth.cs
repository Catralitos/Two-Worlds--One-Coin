using Player;

namespace PowerUps
{
    public class RestoreHealth : PowerUp
    {
        public int healthToRestore;

        public override void TriggerEffect()
        {
            PlayerEntity.Instance.Health.RestoreHealth(healthToRestore);
        }
    }
}