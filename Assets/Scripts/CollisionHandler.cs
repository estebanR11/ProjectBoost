using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delay;
    AudioSource asource;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;

    [SerializeField] ParticleSystem successParticle;
    [SerializeField] ParticleSystem crashParticle;
    bool transition = false;
    private void Start()
    {
        asource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {

        if(transition)
        {
            return;
        }
        else
        {
            switch (collision.gameObject.tag)
            {
                case "Friendly":
                    Debug.Log("");
                    break;

                case "Finish":
                    StartCongrats();
                    break;
                case "Fuel":
                    Debug.Log("");
                    break;
                default:
                    StartCrash();
                    break;
            }
        }
      
    }

    void StartCrash()
    {
        transition = true;
        asource.Stop();
        crashParticle.Play();
        asource.PlayOneShot(crash);
            GetComponent<Movement>().enabled = false;
            Invoke("ReloadLevel", delay);
      
        
    }
    void ReloadLevel()
    {
        int actualScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(actualScene);

    }
    void StartCongrats()
    {
        transition = true; asource.Stop();
        successParticle.Play();
        asource.PlayOneShot(success);
            GetComponent<Movement>().enabled = false;
            Invoke("LoadNextLevel", delay);
      
      
    }
    void LoadNextLevel()
    {
        int nextLevel = SceneManager.GetActiveScene().buildIndex;
        if(SceneManager.sceneCount == nextLevel)
        {
            nextLevel = 0;
        }
        else
        {
            nextLevel++;
        }
        SceneManager.LoadScene(nextLevel);
    }
}
