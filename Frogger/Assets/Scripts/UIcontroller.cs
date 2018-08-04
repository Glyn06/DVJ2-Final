using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour {

    public Text livesText;
    public Text scoreText;
    public Text timeText;

    public float seconds;
    public float minutes;

    private void Update()
    {
        seconds = (int)(Time.unscaledTime % 60f);
        minutes = (int)(Time.unscaledTime / 60f);
        timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

        livesText.text = Frog.instance.lives.ToString("000");
    }
}
