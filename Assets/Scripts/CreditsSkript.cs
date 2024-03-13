using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CreditsSkript : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void StartCredits()
    {
        SceneManager.LoadScene("Credits");
        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Menu");
    }
}