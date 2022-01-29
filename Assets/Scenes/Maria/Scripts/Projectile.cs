using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJBoss{
    public class Projectile : MonoBehaviour
    {
        public float speed;

        private Transform player;
        private Vector2 target;
        private Vector3 movementVector = Vector3.zero;
        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            target = new Vector2(player.position.x, player.position.y);

            Vector2 movementVector = (transform.position - player.position).normalized * speed*Time.deltaTime;
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            //transform.position += movementVector * Time.deltaTime;

            Transform currentPlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
            if(transform.position.x == target.x && transform.position.y == target.y){
                DestroyProjectile();
            }

            /*if(transform.position.x == currentPlayerPos.position.x && transform.position.y == currentPlayerPos.position.y){
                DestroyProjectile();
            } else{
              //  if timer*/
        }

        void OnTriggerEnter2D(Collider2D other){
            if(other.CompareTag("Player")){
                DestroyProjectile();
            }
        }

        void DestroyProjectile(){
            Destroy(gameObject);
        }
    }

}