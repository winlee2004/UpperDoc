using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;
using System;
using System.IO;

public class test : MonoBehaviour
{
    private string a = "user|1|02/12/1222|98|user|2|02/12/1222|97|user|3|02/12/1222|96";
    public List<int> users;
    public string user;
    string bb;
    private string lines;
    public Text timer;
    public Text timerr;
    public Text timerrr;
    public Text testif;
    private DateTime c;
    int testa = 100;
    double testb = 0;
    void Start()
    {
        user = PlayerPrefs.GetString("user");
        string part = Application.persistentDataPath + "/" + user + "point" + ".txt";
        lines = File.ReadAllText(part);
        string[] b = lines.Split('|');
        string time = System.DateTime.UtcNow.ToLocalTime().ToString("d/MM/yyyy");
        DateTime timee = DateTime.Now;
        int c = b.Length;
        Debug.Log(c);
        for (int i = 3; i < b.Length; i += 4)
        {

            Debug.Log(b[i]);
            users.Add(Convert.ToInt16(b[i]));

        }
        Debug.Log("0000000000000");
        foreach (int j in users)
        {
            Debug.Log(j);
        }
        Debug.LogWarning(PlayerPrefs.GetString("user"));
        Debug.Log(time);
        Debug.Log(timee.ToString("yyyy/MM/dd"));
        timer.text = (DateTime.UtcNow.ToLocalTime().ToString("d/MM/yyyy"));
        timerr.text = (timee.ToString("d/M/yyyy"));
        Debug.Log(lines);
        Debug.Log("------------------------------------------------------");

        string f = timee.ToString("d/M/yyyy");
        string[] d = f.Split('/');
        Debug.Log(d[0]);
        Debug.Log(d[1]);
        Debug.Log(d[2]);
        if (Convert.ToInt16(d[2]) < 2500)
        {
            int e = Convert.ToInt16(d[2]);
            e = e + 543;
            string timett = d[0] + "/" + d[1] + "/" + e.ToString();
            Debug.Log("timephone = " + timett);
            timerrr.text = "timephoneif = " + timett;
        }
        else
        {
            string timett = f;
            Debug.Log(timett);
            timerrr.text = "timephoneelse = " + timett;
        }
        testb = testa / 3;
        print("---------------------------  " + testb);
        testa = Convert.ToInt16(testb);
        testif.text = testa.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }

}