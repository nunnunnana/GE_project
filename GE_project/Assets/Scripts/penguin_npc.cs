using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class penguin_npc : MonoBehaviour
{
    GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            transform.LookAt(other.transform);
        }
    }
}
