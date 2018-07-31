using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {

    public void M_ChangeScene(string name) {
        SceneManager.LoadScene(name);
    }

    public void M_ExitGame() {
        Application.Quit();
    }
}
