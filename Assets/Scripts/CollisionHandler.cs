using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField]
    float levelLoadDelay = 2f;

    [SerializeField]
    AudioClip crash;

    [SerializeField]
    AudioClip success;

    AudioSource asrc;

    bool isTransitioning = false;

    void Start()
    {
        asrc = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning)
            return;

        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is friendly!");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    void StartSuccessSequence()
    {
        // todo:
        // -add success particle
        isTransitioning = true;
        asrc.Stop();
        GetComponent<Movement>().enabled = false;
        asrc.PlayOneShot(success);
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void StartCrashSequence()
    {
        // todo:
        // -add crash particle
        isTransitioning = true;
        asrc.Stop();
        GetComponent<Movement>().enabled = false;
        asrc.PlayOneShot(crash);
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
