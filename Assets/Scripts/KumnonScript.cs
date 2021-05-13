using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class KumnonScript : MonoBehaviour
{
    string user;
    double sum = 0;
    double show = 0;
    double show1 = 0;
    double show2 = 0;
    double show3 = 0;
    double show4 = 0;
    double show5 = 0;
    List<int> sums = new List<int>() { 1 };
    List<int> shows = new List<int>() { 1 };
    int nub;
    public GameObject Win;
    public GameObject Win1;
    public GameObject Win2;
    public GameObject Win3;
    public GameObject Win4;
    public GameObject Win5;
    public GameObject Lose;
    public Text texe;
    void Start()
    {
        user = PlayerPrefs.GetString("user");
        string part = Application.persistentDataPath + "/" + user + "point" + ".txt";
        for(int i = 6;i<=10;i++)
        {
            Debug.Log("for start");
            shows.Clear();
            show = 0;
            string lines = File.ReadAllText(part);
            string[] check = lines.Split('|');
            for (int k = 1; k < check.Length; k += 4)
            {
                Debug.Log("for kumnuan");
                if (check[k] == i.ToString())
                {
                    shows.Add(Convert.ToInt16(check[k + 2]));                   
                    //sum = sum+ Convert.ToInt16(check[i + 2]);
                    //Debug.Log(sum);
                    //nub++;
                }
            }
            shows.Add(0);
            shows.Add(0);
            for (int j = 0; j < shows.Count; j++)
            {
                Debug.Log("for kumnuan 2");
                if (show < shows[j])
                {
                    show += shows[j];
                }
            }
            if (i==6 && show >= 100)
            {
                Win1.SetActive(true);
            }
            else if(i == 7 && show >= 100)
            {
                Win2.SetActive(true);
            }
            else if(i==8 && show >= 100)
            {
                Win3.SetActive(true);
            }
            else if(i==9 && show >= 100)
            {
                Win4.SetActive(true);
            }
            else if(i==10 && show >= 100)
            {
                Win5.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Click1 ()
    {
        string game = "6";
        texe.text = "รูปแบบที่ 1";
        KumnumSum(game);        
    }
    public void Click2()
    {
        string game = "7";
        texe.text = "รูปแบบที่ 2";
        KumnumSum(game);
        
    }
    public void Click3()
    {
        string game = "8";
        texe.text = "รูปแบบที่ 3";
        KumnumSum(game);
        
    }
    public void Click4()
    {
        string game = "9";
        texe.text = "รูปแบบที่ 4";
        KumnumSum(game);       
    }
    public void Click5()
    {
        string game = "10";
        texe.text = "รูปแบบที่ 5";
        KumnumSum(game);       
    }
    private void KumnumSum (string game)
    {
        sums.Clear();
        //sum = 0;
        sums.Add(0);
        string part = Application.persistentDataPath + "/" + user + "point" + ".txt";
        string lines = File.ReadAllText(part);
        string[] check = lines.Split('|');
        for (int i = 1; i < check.Length; i+=4)
        {
            if (check[i] == game)
            {
                sums.Add(Convert.ToInt16(check[i + 2]));
                //sum = sum+ Convert.ToInt16(check[i + 2]);
                //Debug.Log(sum);
                //nub++;
            }
        }
        sums.Add(0);
        sums.Add(0);
        for (int i = 0; i < sums.Count; i++)
        {
            if (sum < sums[i])
            {
                sum += sums[i];
            }
        }
        if (sum > 100)
        {
            Win.SetActive(true);
            Lose.SetActive(false);
        }
        else
        {
            Lose.SetActive(true);
            Win.SetActive(false);
        }
        //if(sum/nub >= 100)
        //{
        //    Win.SetActive(true);
        //    Lose.SetActive(false);
        //    sum = 0;
        //    nub = 0;
        //}
        //else
        //{
        //    Lose.SetActive(true);
        //    Win.SetActive(false);
        //    sum = 0;
        //    nub = 0;
        //}
    }
}
