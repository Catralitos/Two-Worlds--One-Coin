using UnityEngine;
using PowerUps;

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
        public GameObject bossMan;
        public GameObject surrealUI;

        public PowerUpBag Bag;
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
               // bossMan.SetActive(true);
                
                // How cool is this null checker?
                FindObjectOfType<GameManager>()?.ChangeSong("Hell");
                surrealUI.SetActive(true);
                PowerUps.SwitchToNightmare();
                
                ActivateBoss();

            } else if (surrealWorldSprite.activeSelf)
            {   
                PowerUps.SwitchToReal();
              //  bossMan.SetActive(false);
                surrealWorldSprite.SetActive(false);
                realWorldSprite.SetActive(true);
                this.transform.position += new Vector3(-x_Distance, 0.0f, 0.0f);
                FindObjectOfType<GameManager>()?.ChangeSong("Lidl");
                surrealUI.SetActive(false);
                Bag.SpawnTwoPU();

                
            }

            Movement.animator = GetComponentInChildren<Animator>();
        }

        public void DisableBoss()
        {

            bossMan.SetActive(false);
        }

        public void ActivateBoss()
        {
            if(surrealWorldSprite.activeSelf)
                bossMan.SetActive(true);
        }
    }
}