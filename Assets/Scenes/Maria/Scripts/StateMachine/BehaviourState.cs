using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemies.Base;


namespace GGJBoss{
    public abstract class BehaviourState : EnemyState<Behaviour>
    {

        protected static new T Create<T>(Behaviour target) where T : BehaviourState
            {
                T state = EnemyState<Behaviour>.Create<T>(target);
                //TODO do stuff
                //state.textField = target.GetComponent<Text>();
                return state;
            }

        /* protected void SetState(BehaviourState<Behaviour> state)
            {
                target.SetState(state);
                Destroy(this);
            }*/
    }

}