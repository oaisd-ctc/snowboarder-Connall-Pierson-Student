using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecretFinish : MonoBehaviour
{

    [SerializeField] float loadDelay = 3f;
    [SerializeField] ParticleSystem finishEffect;

    bool isFinished = false;
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" && !isFinished)
        {
            isFinished = true;
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", loadDelay);

        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

}
