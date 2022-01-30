using UnityEngine;
using UnityEngine.UI;

namespace Boss{

    public class Boss : EnemyBase<Boss>
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
            protected override void Start()
            {
                //animator = GetComponentInChildren<Animator>();
                //healthBar.value = currentHealth;
                rb = GetComponent<Rigidbody2D>();
                state = IdleState.Create(this);
            }

    }

}