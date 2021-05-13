using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class PlayerFive : MonoBehaviour
{
    Rigidbody2D rb;
    float dirY;
    float dirX;
    public float moveSpeed = 120f;

    public AudioSource finish;
    public AudioSource PP;

    public int points = 0;
    public Text Score;
    public Text TotalScore;
    private string user;
    private string game;
    private string form;
    private string part;
    private string forml;
    private DateTime timerr = DateTime.Now;
    private string time;
    public Dropdown Times;
    public GameObject bg;
    public GameObject btnStartSM;
    public GameObject btnPause;
    public GameObject end;
    public GameObject PauseBg;
    public GameObject PopupTime;
    public GameObject DropTime;
    List<string> TimeD = new List<string>() { "เวลา", "5 นาที", "10 นาที", "15 นาที", "20 นาที" };
    public float totalTime;
    public int timer = 100;

    public Text text;

    private float btn;
    private float minutes;
    private float seconds;
    bool isPaused = false;


    void Start()
    {
        Time.timeScale = 0;
        //StartCoroutine(TimerStartOpen());
        rb = GetComponent<Rigidbody2D>();
        user = PlayerPrefs.GetString("user");
        game = PlayerPrefs.GetString("game");
        Times.AddOptions(TimeD);
        if(game == "6" || game == "7" || game == "8" || game == "9" || game == "10" )
        {
            DropTime.SetActive(false);
        }
        Debug.Log(user);
        Debug.Log(game);

    }
    public void DropdowsTime(int index)
    {
        Debug.Log(index);
        Debug.Log(TimeD[index]);
        if (index == 0)
        {
            timer = 100;
        }
        else if (index == 1)
        {
            timer = 300;
        }
        else if (index == 2)
        {
            timer = 600;
        }
        else if (index == 3)
        {
            timer = 900;
        }
        else
        {
            timer = 1200;
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "point")
        {
            points++;
            PP.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.acceleration.x * moveSpeed;
        dirY = Input.acceleration.y * moveSpeed;
        //transform.position = new Vector2(Mathf.Clamp(transform.position.x,-9.5f, 7.5f), Mathf.Clamp(-9.5f, transform.position.y, 7.5f));
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, dirY);
        Score.text = points.ToString();
        TotalScore.text = points.ToString();
    }
    public void StartClick()
    {
        if (game == "1" || game == "2" || game == "3" || game == "4" || game == "5")
        {
            if (timer <= 100)
            {
                Debug.Log("Time : " + timer);
                PopupTime.SetActive(true);
            }
            else
            {
                bg.SetActive(false);
                btnPause.SetActive(true);
                DropTime.SetActive(false);
                btn = (int)(1);
                Time.timeScale = 1;
                Debug.Log("Time : " + timer);
                StartCoroutine(TimerStartOpen());
            }
        }
        else
        {
            bg.SetActive(false);
            btnPause.SetActive(true);
            DropTime.SetActive(false);
            btn = (int)(1);
            Time.timeScale = 1;
            timer = 300;
            StartCoroutine(TimerStartOpen());
        }
    }
    public void PoptimeClick()
    {
        PopupTime.SetActive(false);
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
        part = Application.persistentDataPath + "/" + user + "point" + ".txt";
        string a = timerr.ToString("d/M/yyyy");
        string[] b = a.Split('/');
        if (Convert.ToInt16(b[2]) < 2500)
        {
            int c = Convert.ToInt16(b[2]);
            c = c + 543;
            time = b[0] + "/" + b[1] + "/" + c.ToString();
        }
        else
        {
            time = a;
        }
        if (File.Exists(part))
        {
            forml = File.ReadAllText(part);
            form = forml + "|" + user + "|" + game + "|" + time + "|" + points.ToString();
            File.WriteAllText(part, form);
        }
        else
        {
            form = user + "|" + game + "|" + time + "|" + points.ToString();
            File.WriteAllText(part, form);
        }
        //form =form+"|"+user + "|" + game + "|" + time + "|" + points.ToString();
        //File.WriteAllText(part, form);
        end.SetActive(true);
        finish.Play();
    }
}
