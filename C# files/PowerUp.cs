using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject pickupEffect;

    public CameraShake cameraShake;



    public float speedDivider = 3f;
   
    public float durationSpeed = 20f;
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
        player.GetComponent<PlayerMovement>().forwardForce /= speedDivider;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        // Wait x amount of seconds
        yield return new WaitForSeconds(durationSpeed);


        // Reverse the effect on your player
        player.GetComponent<PlayerMovement>().forwardForce *= speedDivider;

        // Remove power up object
        Destroy(gameObject);
    }
}
