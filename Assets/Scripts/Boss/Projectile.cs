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

        private Vector3 _movementVector;
        // Start is called before the first frame update
        private void Start()
        {
           
            Vector3 target = PlayerEntity.Instance.gameObject.transform.position;
            _movementVector = (target - transform.position).normalized;

            if (_movementVector.x < 0)
            {
             
                this.GetComponent<SpriteRenderer>().flipX = false;

            }
            else
            {
              
                this.GetComponent<SpriteRenderer>().flipX = true;

            }
        }

        // Update is called once per frame
        private void Update()
        {
            transform.position = transform.position + (speed * Time.deltaTime * _movementVector);
           
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