using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VillainScript : MonoBehaviour
{
    public NavMeshAgent villain;
    public GameObject Player;
    void Start()
    {
        
    }

    
    void Update()
    {
        villain.SetDestination(Player.transform.position);
    }
}
