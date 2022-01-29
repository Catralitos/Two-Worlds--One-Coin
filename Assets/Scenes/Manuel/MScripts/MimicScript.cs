using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicScript : MonoBehaviour
{

    public Transform mainCharacter;
    public float distance = 15.0f;

    void Start()
    {
        mainCharacter = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = mainCharacter.position + new Vector3(distance, 0, 0);
    }
}
