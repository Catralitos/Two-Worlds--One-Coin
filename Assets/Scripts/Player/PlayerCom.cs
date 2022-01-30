using Extensions;
using PowerUps;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerCom : MonoBehaviour
    {

        public bool canAttack = true;
    
        public Transform attackPoint;
        public float attackRange = 0.5f;

        public double attackCooldown = 0;

        public double attackCooldownMax = 0.5;

        public LayerMask projectileLayers;

        public LayerMask bagLayer;

        // Update is called once per frame
        void Update()
        {
            if (attackCooldown > 0)
            {
                attackCooldown -= Time.deltaTime; 
            }
        }

        public void Attack(InputAction.CallbackContext context)
        {
            if (context.performed && canAttack && attackCooldown <= 0)
            {
                Attack();
                attackCooldown = attackCooldownMax;
            }
        
        }

        void Attack()
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, projectileLayers);

            foreach(Collider2D enemy in hitEnemies)
            {
                if (projectileLayers.HasLayer(enemy.gameObject.layer)){
                    Debug.Log("Acertou um projetil");
                }

            }
        }

        void OnDrawGizmosSelected() {
            {
                if (attackPoint == null)
                    return;

                Gizmos.DrawWireSphere(attackPoint.position, attackRange);
            }
        }
    }
}
