using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinUI : MonoBehaviour {

    public Text scoreText;
    public Text timeText;

    GameManager GM;

    private void Start()
    {
        GM = GameManager.instance;
        scoreText.text = "Score: " + GM.score.ToString("0000");
        timeText.text = GM.minutes.ToString("00") + ":" + GM.seconds.ToString("00");
    }
}
