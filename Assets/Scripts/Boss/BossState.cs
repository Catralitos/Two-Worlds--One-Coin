namespace Boss{
    public abstract class BossState : EnemyState<Boss>
    {

        protected static new T Create<T>(Boss target) where T : BossState
            {
                T state = EnemyState<Boss>.Create<T>(target);
                
                return state;
            }

    
    }

}