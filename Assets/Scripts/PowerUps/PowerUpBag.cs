using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PowerUps
{
    public class PowerUpBag : MonoBehaviour
    {
        public float fireSpeed;
        public float minFireAngle;
        public float maxFireAngle;
        public Transform spawnPoint;

        private float time;
    
        public List<GameObject> powerUpPrefabs;

        public void Start()
        {

        }

        public void SpawnPowerUp()
        {
            int index = Random.Range(0, powerUpPrefabs.Count);
            GameObject spawned = Instantiate(powerUpPrefabs[index], spawnPoint.position, Quaternion.identity);
            float randomAngle = Random.Range(minFireAngle, maxFireAngle + 1);
            if (Random.Range(0, 2) % 2 == 0) randomAngle *= -1;
            spawned.GetComponent<Rigidbody2D>().velocity =
                (Quaternion.Euler(0, 0, randomAngle) * Vector2.up).normalized * fireSpeed;
        }

        public void SpawnTwoPU()
        {
            Invoke("SpawnPowerUp", 2f);
            Invoke("SpawnPowerUp", 3f);
        }
        
    }
}