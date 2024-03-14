using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public AudioClip backgroundMusic;
    
    private static GameManager _instance;
    
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Start()
    {
        GameObject audioObject = new GameObject("TempAudio");
        AudioSource tempAudioSource = audioObject.AddComponent<AudioSource>();
        tempAudioSource.clip = backgroundMusic;
        tempAudioSource.volume = 0.8f;
        tempAudioSource.Play();
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartCredits()
    {
        StartCoroutine(LoadAndDisplayCredits());
    }

    private IEnumerator LoadAndDisplayCredits()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Credits");
        
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        
        yield return new WaitForSeconds(5f);
        
        SceneManager.LoadScene("Menu");
    }
}