using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemies.Base;
using UnityEngine.UI;


namespace GGJBoss{

    public class Behaviour : EnemyBase<Behaviour>
    {

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
            protected override void Start()
            {
                //animator = GetComponentInChildren<Animator>();
                healthBar.value = currentHealth;
                rb = GetComponent<Rigidbody2D>();
                state = IdleState.Create(this);
            }

    }

}