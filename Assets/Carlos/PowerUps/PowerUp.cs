using UnityEngine;

namespace PowerUps
{
    public class PowerUp : MonoBehaviour
    {
        public Sprite sprite;

        public float buffDuration;
        private bool _buffTriggered;
        private float _durationLeft;


        private void Start()
        {
            _durationLeft = buffDuration;
        }

        private void Update()
        {
            if (_buffTriggered)
            {
                _durationLeft -= Time.deltaTime;

                if (_durationLeft <= 0.0f)
                {
                    StopEffect();
                }
            }
        }
        
        public virtual void TriggerEffect()
        {
            _buffTriggered = true;
        }

        protected virtual void StopEffect()
        {
            //do nothing
        }
    }
}