using Extensions;
using UnityEngine;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        public LayerMask hitMask;

        public int currentHealth;
        public int maxHealth;
        public int invincibilityFrames;

        //private SpriteRenderer _renderer;
        private Material _defaultMaterial;
        public Material hitMaterial;

        private bool _invincible;
        private int _currentShields;

        private void Start()
        {
            currentHealth = maxHealth;
            _defaultMaterial = GetComponentInChildren<SpriteRenderer>().material;
        }

        public void RestoreHealth(int health)
        {
            currentHealth = Mathf.Clamp(currentHealth + health, 0, maxHealth);
        }

        public void AddShields(int shields)
        {
            _currentShields += shields;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (hitMask.HasLayer(other.gameObject.layer))
            {
                Hit(other.gameObject.GetComponent<Boss.Boss>().contactDamage);
            }
        }

        public void Hit(int damage)
        {
            if (_invincible) return;
            if (_currentShields > 0)
            {
                StartIFrames();
                _currentShields--;
                return;
            }

            currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
            if (currentHealth > 0)
            {
                StartIFrames();
            }
            else
            {
                Die();
            }
        }

        private void StartIFrames()
        {
            _invincible = true;
            GetComponentInChildren<SpriteRenderer>().material = hitMaterial;
            Physics2D.IgnoreLayerCollision(gameObject.layer, PlayerEntity.Instance.bossMan.layer, true);
            //Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(),
            //    PlayerEntity.Instance.bossMan.GetComponent<Collider2D>(), true);
            Invoke(nameof(RestoreVulnerability), invincibilityFrames / 60.0f);
        }

        private void RestoreVulnerability()
        {
            //Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(),
            //   PlayerEntity.Instance.bossMan.GetComponent<Collider2D>(), false);
            Physics2D.IgnoreLayerCollision(gameObject.layer, PlayerEntity.Instance.bossMan.layer, false);
            GetComponentInChildren<SpriteRenderer>().material = _defaultMaterial;
            _invincible = false;
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}