using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    // Property to provide access to the GameManager instance
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        // Ensure only one instance of GameManager exists
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
        // Load the Credits scene asynchronously
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Credits");

        // Wait until the Credits scene has finished loading
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Wait for 5 seconds
        yield return new WaitForSeconds(5f);

        // Load the Menu scene
        SceneManager.LoadScene("Menu");
    }
}