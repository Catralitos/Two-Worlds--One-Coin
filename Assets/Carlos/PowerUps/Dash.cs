using Player;

namespace PowerUps
{
   public class Dash : PowerUp
   {
       public float speedBoost;

       public override void TriggerEffect()
       {
           base.TriggerEffect();
           PlayerEntity.Instance.Movement.canDash = true;
       }

       protected override void StopEffect()
       {
           PlayerEntity.Instance.Movement.canDash = false;
       }
   } 
}

