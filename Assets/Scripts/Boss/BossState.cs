namespace Boss{
    public abstract class BossState : EnemyState<BossEnemy>
    {

        protected static new T Create<T>(BossEnemy target) where T : BossState
            {
                T state = EnemyState<BossEnemy>.Create<T>(target);
                
                return state;
            }

    
    }

}