using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour {

    public Text livesText;
    public Text scoreText;
    public Text timeText;

    GameManager GM;

    private void Start()
    {
        GM = GameManager.instance;
    }

    private void Update()
    {
            timeText.text = GM.minutes.ToString("00") + ":" + GM.seconds.ToString("00");
            livesText.text = Frog.instance.lives.ToString("0");
            scoreText.text = "SCORE: " + GM.score.ToString("0000");
    }
}
