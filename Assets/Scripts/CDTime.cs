using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CDTime : MonoBehaviour
{
    public GameObject bg;
    public GameObject btnStart;
    public GameObject btnStartSM;
    public GameObject btnPause;
    public GameObject gameBG;
    public GameObject end;
    public GameObject PauseBg;

    private string user;
    private string up;
    private string time = System.DateTime.UtcNow.ToLocalTime().ToString("d/M/yyyy");
    public float totalTime;
    public int timer;

    public Text text;

    public int points = 0;
    private float btn;
    private float minutes;
    private float seconds;
    bool isPaused = false;
    
    void Start()
    {
        Time.timeScale = 0;
        StartCoroutine(TimerStartOpen());
    }

    public void StartClick()
    {
        btnStart.SetActive(false);
        bg.SetActive(false);
        gameBG.SetActive(true);
        btnPause.SetActive(true);
        btn = (int)(1);
        timer = 60;
        Time.timeScale = 1;
    }

    public void PauseClick()
    {
        btn = (int)(0);
        btnPause.SetActive(false);
        PauseBg.SetActive(true);
        btnStartSM.SetActive(true);
        Time.timeScale = 0;
    }
    public void StartSMClick()
    {
        btn = (int)(1);
        btnStartSM.SetActive(false);
        btnPause.SetActive(true);
        PauseBg.SetActive(false);
        Time.timeScale = 1;
    }
    public void Resume()
    {
        PauseBg.SetActive(false);
        btnStartSM.SetActive(false);
        btnPause.SetActive(true);
        Time.timeScale = 1;
    }
    public void StopGame()
    {
        Application.LoadLevel("PSForm");
    }
    public void Endgame()
    {
        Application.LoadLevel("PSForm");
    }
    void Update()
    {
        //if (btn == 1)
        //{
        //    //if(totalTime == 0)
        //    //{
        //    //    Time.timeScale = 0;
        //    //}
        //    //else
        //    //{
        //    //    totalTime -= Time.deltaTime;
        //    //    minutes = (int)(totalTime / 60);
        //    //    seconds = (int)(totalTime % 60);
        //    //    //text.text = minutes.ToString() + " : " + seconds.ToString();
        //    //    text.text = totalTime.ToString();
        //    //    if (totalTime == 0)
        //    //    {
        //    //        Time.timeScale = 0;
        //    //    }
        //    //}

        //    //}
        //    //else
        //    //{
        //    //    text.text = minutes.ToString() + " : " + seconds.ToString();
        //    //}
        //}
    }

    IEnumerator TimerStartOpen()
    {
        while (timer > 0)
        {
            minutes = (int)(timer / 60);
            seconds = (int)(timer % 60);
            text.text = minutes.ToString() + ":" + seconds.ToString();
            yield return new WaitForSeconds(1f);
            timer--;
        }
        text.text = totalTime.ToString();
        Time.timeScale = 0;
        end.SetActive(true);
        //user = PlayerPrefs.GetString(user);
        //up = PlayerPrefs.GetString(userpoint);
    }
}
