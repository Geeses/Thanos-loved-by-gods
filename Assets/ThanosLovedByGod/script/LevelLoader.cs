using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    public Canvas DebugUI;
    public Image loadingBar;
    public Image Check;

    private bool debug = false;

    public void Options()
    {
        //
    }

    public void Quit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit ();
        #endif
    }

    public void ActivateDebug()
    {
        if (!debug)
        {
            debug = true;
            Check.enabled = true;
            DebugUI.enabled = true;
        }
        else
        {
            debug = false;
            Check.enabled = false;
            DebugUI.enabled = false;
        }

    }

    public bool IsDebugEnabled()
    {
        return debug;
    }
    
    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsync(sceneIndex));
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingBar.fillAmount = progress;
            yield return null;
        }
        
    }

}

