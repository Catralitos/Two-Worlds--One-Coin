using Extensions;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public LayerMask hitMask;
    
    public int currentHealth;  
    public int maxHealth;
    public int invincibilityFrames;
    
    private bool _invincible;
    private int _currentShields; 
    
    private void Start()
    {
        currentHealth = maxHealth;
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
            //tirar dano isso agora depende de como metemos o dano de cada coisa
        }
    }

    private void Hit(int damage)
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
        Invoke(nameof(RestoreVulnerability), invincibilityFrames / 60.0f);
    }

    private void RestoreVulnerability()
    {
        _invincible = false;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}