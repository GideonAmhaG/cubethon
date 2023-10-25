using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSize : MonoBehaviour
{
    public GameObject pickupEffect;

    public CameraShake cameraShake;

    public float sizeDivider = 3f;
  
    public float durationSize = 4f;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
            StartCoroutine(cameraShake.Shake(0.15f, 0.4f));
        }
    }

    IEnumerator Pickup(Collider player)
    {
        // Spawn a cool effect
        Instantiate(pickupEffect, transform.position, transform.rotation);

        // Apply effect to the player
        player.transform.localScale = new Vector3(1/sizeDivider, 1, 1);

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        // Wait x amount of seconds
        yield return new WaitForSeconds(durationSize);


        // Reverse the effect on your player
        player.transform.localScale = new Vector3(1, 1, 1);

        // Remove power up object
        Destroy(gameObject);
    }

    
}

