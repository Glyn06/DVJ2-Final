using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

    bool isPaused = false;

    public List<GameObject> onPauseShow;
    public List<GameObject> onPauseHide;
    public Slider slider;
    public Text nextLevelText;
    public GameObject panel;

    public void M_ChangeScene(string name) {
        if (GameManager.instance != null)
            GameManager.instance.ResetTimers();
        Time.timeScale = 1;
        SceneManager.LoadScene(name);
    }

    public void M_ExitGame() {
        Application.Quit();
    }

    public void M_PauseButton() {
        if (isPaused)
        {
            Time.timeScale = 1;
            for (int i = 0; i < onPauseShow.Count; i++)
            {
                onPauseShow[i].SetActive(false);
            }
            for (int i = 0; i < onPauseHide.Count; i++)
            {
                onPauseHide[i].SetActive(true);
            }
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            for (int i = 0; i < onPauseShow.Count; i++)
            {
                onPauseShow[i].SetActive(true);
            }
            for (int i = 0; i < onPauseHide.Count; i++)
            {
                onPauseHide[i].SetActive(false);
            }
            isPaused = true;
        }
    }

    public void M_NextLevel() {

        panel.SetActive(true);

        if (!GameManager.instance)
        {
            nextLevelText.text = "Level 1";
            
        }
        else
        {
            nextLevelText.text = "Level " + GameManager.instance.nextLevel.ToString();

        }
        StartCoroutine(LoadAsynch(GameManager.instance.nextLevel));
        Time.timeScale = 1;
        GameManager.instance.nextLevel++;
        GameManager.instance.ResetTimers();
    }

    IEnumerator LoadAsynch(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f); //la division por 0.9 es para que vaya de 0 a 1 y no de 0 a 0.9
            slider.value = progress;

            yield return null;
        }
    }
}
