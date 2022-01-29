using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;


namespace GGJBoss{
        
    public class Boss : MonoBehaviour
    {
        private float timeBtwnShots;
        public float startTimeBtwnShots;

        public Animator animator;

        public Transform player; 
        public GameObject projectile;  

        public float speed;

        public Rigidbody2D rb;
        public float dashSpeed;
        private float dashTime;
        public float startDashTime;
        //private float direction;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            dashTime = startDashTime;

            player = PlayerEntity.Instance.gameObject.transform;
            timeBtwnShots = startTimeBtwnShots;
        }

        // Update is called once per frame


    void Update()
        {
            if(timeBtwnShots <= 0){
                Instantiate(projectile, new Vector2 (transform.position.x, transform.position.y), Quaternion.identity);
                timeBtwnShots = startTimeBtwnShots;
            } else{
                timeBtwnShots -= Time.deltaTime;
            }

            if(gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Jump")){
                Vector2 target = new Vector2(player.position.x, transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            }
        }
    }

}