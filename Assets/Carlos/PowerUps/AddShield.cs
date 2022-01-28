using Player;

namespace PowerUps
{
    public class AddShield : PowerUp
    {
        public int hitsShielded;

        public override void TriggerEffect()
        {
            PlayerEntity.Instance.Health.AddShields(hitsShielded);
        }
    }
}


