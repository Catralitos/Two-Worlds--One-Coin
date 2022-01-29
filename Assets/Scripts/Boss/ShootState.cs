using UnityEngine;

namespace Boss{
    public class ShootState : BossState
    {
        private float timeBtwnShots;
        public float startTimeBtwnShots = 0.5f; 
        public float t = 0;
        // Start is called before the first frame update
        public override void StateStart(){
            // target.animator.SetTrigger("shoot");
                base.StateStart();
                t = 0;
                timeBtwnShots = startTimeBtwnShots;

            }

            public override void StateUpdate()
            {
                t += Time.deltaTime;
                //TODO
                //play animation

                if(timeBtwnShots <= 0){
                    Instantiate(Resources.Load("Projectile"), new Vector2 (transform.position.x, transform.position.y), Quaternion.identity);
                    timeBtwnShots = startTimeBtwnShots;
                } else{
                    timeBtwnShots -= Time.deltaTime;
                }

                if (t > 5)
                {
                    //target.startDash = true;
                    SetState(DashState.Create(target));
                }
            }

            public static ShootState Create(Boss target)
            {
                return BossState.Create<ShootState>(target);
            }
    }
}
