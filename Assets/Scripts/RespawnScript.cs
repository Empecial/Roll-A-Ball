using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform RespawnPoint;
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Respawn Point"))
        {
            player.transform.position = RespawnPoint.transform.position;
            Physics.SyncTransforms();
        }
    }

    

}
