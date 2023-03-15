using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretEnterence : MonoBehaviour
{
    //  [SerializeField] float loadDelay = 0.5f;
    // [SerializeField] ParticleSystem secretEnterence;
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // secretEnterence.Play();
            GetComponent<AudioSource>().Play();
            // Invoke("ReloadScene", loadDelay);

        }
    }
}
