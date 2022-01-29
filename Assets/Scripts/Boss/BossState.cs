namespace Boss{
    public abstract class BossState : EnemyState<Boss>
    {

        protected static new T Create<T>(Boss target) where T : BossState
            {
                T state = EnemyState<Boss>.Create<T>(target);
                //TODO do stuff
                //state.textField = target.GetComponent<Text>();
                return state;
            }

        /* protected void SetState(BossState<Boss> state)
            {
                target.SetState(state);
                Destroy(this);
            }*/
    }

}