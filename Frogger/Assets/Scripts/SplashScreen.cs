using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour {

    public RawImage[] images;
    public float waitingTime = 2;
    public float fading = 3;

    private Color color;
    private bool isDone = false;
    private float time = 0;
    private float alpha = 0;
    private int currentIMG = 0;

    private void Start()
    {
        color.r = color.g = color.b = 255;
        color.a = 0;

        for (int i = 0; i < images.Length; i++)
        {
            images[i].color = color;
        }
    }

    private void Update()
    {
        if (currentIMG < images.Length)
        {
            if (!isDone && alpha < 1)
            {
                alpha += Time.deltaTime / fading;
                color.a = alpha;
                images[currentIMG].color = color;
            }
            else
            {
                time += Time.deltaTime;
                if (time >= waitingTime)
                {
                    isDone = true;
                    alpha -= Time.deltaTime / fading;
                    color.a = alpha;
                    images[currentIMG].color = color;
                    if (alpha <= 0)
                    {
                        currentIMG++;
                        isDone = false;
                        time = 0;
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < images.Length; i++)
            {
                images[i].gameObject.SetActive(false);
            }
            this.enabled = false;
        }
    }
}
