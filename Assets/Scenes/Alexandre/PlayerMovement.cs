using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [HideInInspector] public bool canDash;
        public float moveSpeed;
        [HideInInspector] public float currentMoveSpeed;
        public float jumpPower;
        [HideInInspector] public float currentJumpPower;
        
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}