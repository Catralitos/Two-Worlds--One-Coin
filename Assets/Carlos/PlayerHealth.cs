using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

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
}
