using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {

    bool isPaused = false;

    public List<GameObject> onPauseShow;
    public List<GameObject> onPauseHide;

    public void M_ChangeScene(string name) {
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
}
