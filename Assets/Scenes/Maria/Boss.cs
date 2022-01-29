using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private float timeBtwnShots;
    public float startTimeBtwnShots;

    public Transform player; 
    public GameObject projectile;   

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwnShots = startTimeBtwnShots;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBtwnShots <= 0){
            Debug.Log("INSTANTIATE");
            Instantiate(projectile, new Vector2 (transform.position.x, transform.position.y), Quaternion.identity);
            timeBtwnShots = startTimeBtwnShots;
        } else{
            timeBtwnShots -= Time.deltaTime;
        }

        //Vector2 target = new Vector2(playerPos.position.x, animator.transform.position.y);
        //animator.transform.position = Vector2.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);
    }
}
