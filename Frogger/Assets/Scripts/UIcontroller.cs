using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour {

    public Text livesText;
    public Text scoreText;
    public Text timeText;

    float seconds;
    float minutes;
    float count = 0;

    private void Update()
    {
        count += Time.deltaTime;
        seconds = (int)(count % 60);
        minutes = (int)(count / 60);
        timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

        livesText.text = Frog.instance.lives.ToString("000");
    }
}
