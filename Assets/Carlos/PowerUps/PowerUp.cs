using Extensions;
using UnityEngine;

namespace PowerUps
{
    public class PowerUp : MonoBehaviour
    {
        public LayerMask playerMask;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (playerMask.HasLayer(other.gameObject.layer))
            {
                TriggerEffect();
                Destroy(gameObject);
            }
        }

        protected virtual void TriggerEffect()
        {
        }
    }
}