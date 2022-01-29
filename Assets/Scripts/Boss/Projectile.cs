using Extensions;
using Player;
using UnityEngine;

namespace Boss{
    public class Projectile : MonoBehaviour
    {
        public LayerMask playerLayer;
        public LayerMask destroyMask;
        public float speed;
        public int damage;

        private Vector2 _movementVector;
        // Start is called before the first frame update
        private void Start()
        {
            Vector3 target = PlayerEntity.Instance.gameObject.transform.position;
            _movementVector = (target - transform.position).normalized;
        }

        // Update is called once per frame
        private void Update()
        {
            transform.position = speed * Time.deltaTime * _movementVector;
           
        }

        private void OnTriggerEnter2D(Collider2D other){
            if(playerLayer.HasLayer(other.gameObject.layer))
            {
                PlayerEntity.Instance.Health.Hit(damage);
                Destroy(gameObject);
            }

            if (destroyMask.HasLayer(other.gameObject.layer))
            {
                Destroy(gameObject);
            }
        }
    }

}