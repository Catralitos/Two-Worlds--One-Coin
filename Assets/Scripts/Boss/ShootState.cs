using UnityEngine;
using Player;

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

                target.animator.Play("Base Layer.IntroShoot", 0, 0.0f);
                target.checkDirection();
            }

            public override void StateUpdate()
            {
                t += Time.deltaTime;
                //TODO
                //play animation

                if(timeBtwnShots <= 0){
                    target.animator.Play("Base Layer.Shoot", 0, 0.0f);
                    target.checkDirection();
                    
                    Instantiate(target.projectile, new Vector2 (transform.position.x, transform.position.y), Quaternion.identity);
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

            public static ShootState Create(BossEnemy target)
            {
                return BossState.Create<ShootState>(target);
            }
    }
}
