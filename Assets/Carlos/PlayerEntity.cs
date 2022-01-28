using UnityEngine;

namespace Player
{
    public class PlayerEntity : MonoBehaviour
    {
        [HideInInspector] public static PlayerEntity Instance { get; private set; }
        [HideInInspector] public PlayerHealth Health;
        [HideInInspector] public PlayerMovement Movement;
        [HideInInspector] public PlayerPowerUps PowerUps;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Debug.LogWarning("Multiple players present in scene! Destroying...");
                Destroy(gameObject);
            }

            Movement = GetComponent<PlayerMovement>();
            Health = GetComponent<PlayerHealth>();
            PowerUps = GetComponent<PlayerPowerUps>();
            //Controller = GetComponent<PlayerControls>();
            //Combat = GetComponent<PlayerCombat>();
            //UI = GetComponent<PlayerUI>();
        }
    }
}