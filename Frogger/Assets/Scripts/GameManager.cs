using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour {
    #region Singleton
    public static GameManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;
    }
    #endregion

    [HideInInspector] public int score = 0;
    [HideInInspector] public int level = 1;
    [HideInInspector] public float seconds;
    [HideInInspector] public float minutes;
    [HideInInspector] public float count = 0;

    private void Update()
    {
        count += Time.deltaTime;
        seconds = (int)(count % 60);
        minutes = (int)(count / 60);
    }

    public void ResetTimers() {
        seconds = 0;
        minutes = 0;
        count = 0;
    }
}
