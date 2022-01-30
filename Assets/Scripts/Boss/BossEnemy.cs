using UnityEngine;
using UnityEngine.UI;

namespace Boss{

    public class BossEnemy : EnemyBase<BossEnemy>
    {

        public GameObject projectile;
        
        public float TimeBetweenStates;

        public float jumpForce;
        [HideInInspector] public int numJumps;
        [HideInInspector] public int numDash;
        public bool startDash;
        public float maxHeight;

        public float dashSpeed;

        public int hitDamage;

        public int ceilingJump;

        public Slider healthBar;

        public Transform player;

        [HideInInspector] public AudioSource audioData;
        public AudioClip laugh;
            protected override void Start()
            {
                //animator = GetComponentInChildren<Animator>();
                //healthBar.value = currentHealth;
                rb = GetComponent<Rigidbody2D>();
                audioData = GetComponentInChildren<AudioSource>();
                state = IdleState.Create(this);
            }

    }

}