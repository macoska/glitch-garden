using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] [Range(0, 10)] int splashScreenDuration = 3;

    // state variables
    int currentSceneIndex, maxSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        maxSceneIndex = SceneManager.sceneCountInBuildSettings - 1;
        if (currentSceneIndex == 0)
            StartCoroutine(LoadSceneWithDelay(1, splashScreenDuration));
    }

    public void LoadNextScene()
    {
        int nextScene = currentSceneIndex < maxSceneIndex ? currentSceneIndex + 1 : 1;
        SceneManager.LoadScene(nextScene);
    }
    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void LoadStartScreen()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }
    public void LoadOptionsScreen() => SceneManager.LoadScene("Options Screen");

    IEnumerator LoadSceneWithDelay(int scene, int delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scene);
    }

    public void LoadYouLose(int delay)
    {
        int scene = maxSceneIndex; //SceneManager.GetSceneByName("You Lose Screen").buildIndex; // for some reason doesnt work
        if (delay > 0f)
            StartCoroutine(LoadSceneWithDelay(scene, delay));
        else
            SceneManager.LoadScene(scene);
    }

    public void QuitGame() => Application.Quit();
}
