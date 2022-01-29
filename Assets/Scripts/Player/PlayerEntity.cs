using UnityEngine;

namespace Player
{
    public class PlayerEntity : MonoBehaviour
    {
        [HideInInspector] public static PlayerEntity Instance { get; private set; }
        [HideInInspector] public PlayerHealth Health;
        [HideInInspector] public PlayerMovement Movement;
        [HideInInspector] public PlayerPowerUps PowerUps;

        public GameObject realWorldSprite;
        public GameObject surrealWorldSprite;

        public float x_Distance = 15;
     
        
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


        public void ChangeAvatar()
        {
            if (realWorldSprite.activeSelf)
            {
                realWorldSprite.SetActive(false);
                surrealWorldSprite.SetActive(true);
                this.transform.position += new Vector3(x_Distance, 0.0f, 0.0f);

            } else if (surrealWorldSprite.activeSelf)
            {
                surrealWorldSprite.SetActive(false);
                realWorldSprite.SetActive(true);
                this.transform.position += new Vector3(-x_Distance, 0.0f, 0.0f);
            }
        }
    }
}