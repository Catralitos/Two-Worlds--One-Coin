using System.Collections.Generic;
using Extensions;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies.Base
{
    public abstract class EnemyBase : MonoBehaviour
    {
        public bool isAlive
        {
            get => currentHealth > 0;
        }

        public virtual bool IsAlive
        {
            get => currentHealth > 0;
        }

        public LayerMask groundMask;
        public LayerMask playerMask;

        public LayerMask wallMask;

        public LayerMask ceilingMask;
        
        public int currentHealth;
        public int maxHealth;
        
        public int contactDamage;
        private float _initialMass;
        private RigidbodyConstraints2D _initialConstraints;

        [HideInInspector] public Rigidbody2D rb;

        public bool grounded;
        public bool wallHitLeft;
        public bool wallHitRight;
        public bool ceilingHit;

        public float horizontalVelocity;
        
        protected virtual void Start()
        {
            rb = GetComponent<Rigidbody2D>();            
            currentHealth = maxHealth;
             _initialMass = rb.mass;
            _initialConstraints = rb.constraints;
        }

        public virtual void Hit(int damage){
            
        }
        

        public void Call(string messageName)
        {
            SendMessage(messageName);
        }

        
        protected virtual void Die()
        {
            Destroy(gameObject);
        }
        

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (playerMask.HasLayer(other.gameObject.layer))
            {
               
                //PlayerEntity.Instance.Health.Hit(contactDamage);
                rb.velocity = Vector2.zero;
                rb.mass = 100000000000;
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
            }

            if (groundMask.HasLayer(other.gameObject.layer)){
                grounded = true;
            }

            if (wallMask.HasLayer(other.gameObject.layer)){
                if(other.gameObject.transform.position.x > transform.position.x)
                    wallHitRight = true;
                else
                    wallHitLeft = true;
            }
            
            if (ceilingMask.HasLayer(other.gameObject.layer)){
                ceilingHit = true;
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (playerMask.HasLayer(other.gameObject.layer))
            {
                rb.constraints = _initialConstraints;
                rb.mass = _initialMass;
            }
             if (groundMask.HasLayer(other.gameObject.layer)){
                 grounded = false;
            }
            
             if (wallMask.HasLayer(other.gameObject.layer)){
                if(other.gameObject.transform.position.x > transform.position.x)
                    wallHitRight = false;
                else
                    wallHitLeft = false;
            }
            
            if (ceilingMask.HasLayer(other.gameObject.layer)){
                ceilingHit = false;
            }
        }
    }

    public abstract class EnemyBase<EnemyType> : EnemyBase where EnemyType : EnemyBase<EnemyType>
    {
        protected EnemyState<EnemyType> state;

        public void SetState(EnemyState<EnemyType> state)
        {
            Destroy(this.state);
            this.state = state;
        }
        
    
        public override void Hit(int damage)
        {
            if (isAlive)
            {
                currentHealth = Mathf.Max(currentHealth - damage, 0);
                //state.OnGetHit();
                if (!IsAlive) Die();
            }
        }

        protected virtual void Update()
        {
            if (IsAlive)
            {
                if (!state.Initialized)
                {
                    state.StateStart();
                }

                state.StateUpdate();
            }
        }

        protected virtual void FixedUpdate()
        {
            if (IsAlive)
            {
                if (!state.Initialized)
                {
                    state.StateStart();
                }

                state.StateFixedUpdate();
            }
        }
        
    }
}