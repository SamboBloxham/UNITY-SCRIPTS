using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{

    public static SceneLoader Instance { get; private set; }

    [SerializeField] GameObject canvas;

    [SerializeField] Slider loadingBar;


    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }



    private bool isLoading = false; // Flag to prevent loading multiple scenes simultaneously


    public void LoadScene(string sceneName)
    {
        if (!isLoading)
        {
            canvas.SetActive(true);
            if(loadingBar != null) loadingBar.value = 0;
            StartCoroutine(LoadSceneAsync(sceneName));
        }
    }


    private IEnumerator LoadSceneAsync(string sceneName)
    {
        isLoading = true;

        // Load the new scene additively in the background
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        // Wait until the new scene has finished loading
        while (!asyncLoad.isDone)
        {

            if (loadingBar != null) loadingBar.value = asyncLoad.progress;

            yield return null;
        }


        if (loadingBar != null) loadingBar.value = 1;

        // Unload the currently loaded scene
        Scene[] currentScenes = SceneManager.GetAllScenes();


        foreach (var scene in currentScenes)
        {
            if (scene.name != "SceneLoader" && scene.name != sceneName)
                SceneManager.UnloadSceneAsync(scene);
        }

        isLoading = false;



    }




    public void ResetApp()
    {
        SceneManager.LoadScene(0);
    }




}
