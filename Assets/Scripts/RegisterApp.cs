using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;


public class RegisterApp : MonoBehaviour
{
    public GameObject username;
    public GameObject password;
    public GameObject namesur;
    public GameObject birthday;
    public GameObject birthmount;
    public GameObject birthyear;
    public GameObject popuser;
    public GameObject popuser2;
    public GameObject poppass;
    public GameObject poppass6;
    public GameObject poppass7;
    public GameObject popsurn;
    public GameObject popbirth;
    public GameObject popbirth9;
    public GameObject Compls;
    private string Username;
    private string Password;
    private string Namesur;
    private string Birthday;
    private string Birthmount;
    private string Birthyear;
    private string form;
    private bool UsernameValid = false;
    private bool PasswordValid = false;
    private bool BirthValid = false;

    public Dropdown DayD;
    public Dropdown MountD;
    public Dropdown YearD;
    private string DayS;
    private string MountS;
    private string YearS;
    int a = 2480;
    string b;
    string c;
    List<string> day = new List<string>() { "วัน" };
    List<string> mount = new List<string>() { "เดือน", "มกราคม", "กุมภาพันธ์", "มีนาคม", "เมษายน", "พฤษภาคม", "มิถุนายน", "กรกฏาคม", "สิงหาคม", "กันยายน", "ตุลาคม", "พฤศจิกายน", "ธันวาคม" };
    List<string> year = new List<string>() { "1" };

    private string[] Characters = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
                                   "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
                                   "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "@", "!", "#", "%", "&", "_", "-", ".", "/", "+", "*",};
    private string[] number = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

    void Start()
    {
        day.Clear();
        year.Clear();
        for(int i = 0;i<=32;i++)
        {
            if(i == 0)
            {
                day.Add("วัน");
            }
            else
            {
                day.Add(i.ToString());
            }
        }
        for(int i =0; i<=85;i++)
        {
            if(i == 0)
            {
                year.Add("ปี");
            }
            else
            {
                b = a.ToString();
                year.Add(b);
                a++;
            }
        }
        DayD.AddOptions(day);
        MountD.AddOptions(mount);
        YearD.AddOptions(year);
    }
    public void daydd(int dd)
    {

        DayS = day[dd];
        Debug.Log(DayS);
        if (dd == 0)
        {
            Debug.Log("ยังไม่ได้เลือกวัน");
        }
    }
    public void mountdd(int mm)
    {
              
        if(mm == 1)
        {
            MountS = "1";
        }
        else if (mm == 2)
        {
            MountS = "2";
        }
        else if (mm == 3)
        {
            MountS = "3";
        }
        else if (mm == 4)
        {
            MountS = "4";
        }
        else if (mm == 5)
        {
            MountS = "5";
        }
        else if (mm == 6)
        {
            MountS = "6";
        }
        else if (mm == 7)
        {
            MountS = "7";
        }
        else if (mm == 8)
        {
            MountS = "8";
        }
        else if (mm == 9)
        {
            MountS = "9";
        }
        else if (mm == 10)
        {
            MountS = "10";
        }
        else if (mm == 11)
        {
            MountS = "11";
        }
        else if (mm == 12)
        {
            MountS = "12";
        }
        else
        {
            Debug.Log("ยังไม่ได้เลือกเดือน");
        }
        Debug.Log(MountS);

    }
    public void yeardd(int yy)
    {
        
        YearS = year[yy];
        Debug.Log(YearS);
    }
    public void LoadScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
    public void RegisterButton()
    {
        string path = Application.persistentDataPath + "/" + Username + ".txt";
        bool UN = false;
        bool PW = false;
        bool NS = false;
        bool BD = false;
        if (Username != "")
        {
            Usernamevalidation();
            if (!System.IO.File.Exists(path) && UsernameValid == true)
            {
                UN = true;
            }
            else
            {
                Debug.LogWarning("Username Taken");
                popuser2.SetActive(true);
            }
        }
        else
        {
            Debug.LogWarning("Username Field Empty");
            popuser.SetActive(true);
        }
        if (Password != "")
        {
            Passwordvalidation();
            if (Password.Length > 5 && PasswordValid == true)
            {
                PW = true;
            }
            else
            {
                Debug.LogWarning("Password Must Be Atleast 6 Characters long");
                poppass6.SetActive(true);
            }
        }
        else
        {
            Debug.LogWarning("Password Field Empty");
            poppass.SetActive(true);
        }
        if (Namesur != "")
        {
            NS = true;
        }
        else
        {
            Debug.LogWarning("Name & Surname Field Empty");
            popsurn.SetActive(true);
        }
        if(DayS != "0" && MountS !="0" && YearS != "0")
        {
            BD = true;
            Birthday = DayS + "/" + MountS + "/" + YearS;
        }
        else
        {
            Debug.Log("ไม่ได้ใส่ไรซักอย่าง");
            popbirth.SetActive(true);
        }
        //if (Birthday != "" && Birthmount != "" && Birthyear != "")
        //{
        //    Birthvalidation();
        //    if (Birthday.Length > 0 && Birthmount.Length > 0 && Birthyear.Length > 3 && BirthValid == true)
        //    {
        //        BD = true;
        //    }
        //    else
        //    {
        //        Debug.LogWarning("Birthday Must Be Atleast 10 Characters long");
        //        popbirth9.SetActive(true);
        //    }
        //}
        //else
        //{
        //    Debug.LogWarning("Brithday Field Empty");
        //    popbirth.SetActive(true);
        //}
        if (UN == true && PW == true && NS == true && BD == true)
        {
            bool Clear = true;
            int i = 1;
            foreach (char c in Password)
            {
                if (Clear)
                {
                    Password = "";
                    Clear = false;
                }
                i++;
                char Encrypted = (char)(c * i);
                Password += Encrypted.ToString();
            } 
            form = (Username + Environment.NewLine + Password + Environment.NewLine + Namesur + Environment.NewLine + Birthday);    
            System.IO.File.WriteAllText(path, form);
            username.GetComponent<InputField>().text = "";
            password.GetComponent<InputField>().text = "";
            namesur.GetComponent<InputField>().text = "";
            birthday.GetComponent<InputField>().text = "";
            birthmount.GetComponent<InputField>().text = "";
            birthyear.GetComponent<InputField>().text = "";
            Debug.LogWarning("Registration Complete");
            Compls.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Registration False");
        }
    }
    public void Compless()
    {
        Application.LoadLevel("Login");
    }
    public void Closepopup ()
    {
        popuser.SetActive(false);
        popuser2.SetActive(false);
        poppass.SetActive(false);
        poppass6.SetActive(false);
        poppass7.SetActive(false);
        popsurn.SetActive(false);
        popbirth.SetActive(false);
        popbirth9.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Username != "" && Password != "" && Namesur != "" && Birthday != "")
            {
                RegisterButton();
            }
        }
        Username = username.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
        Namesur = namesur.GetComponent<InputField>().text;
        Birthday = birthday.GetComponent<InputField>().text;
        Birthmount = birthmount.GetComponent<InputField>().text;
        Birthyear = birthyear.GetComponent<InputField>().text;
    }
    void Usernamevalidation()
    {
        bool SW = false;
        bool EW = false;
        for(int i = 0;i<Characters.Length;i++)
        {
            if(Username.StartsWith(Characters[i]))
            {
                SW = true;
                Debug.LogWarning("kkkkkkkk");
            }
        }
        for (int i = 0;i<Characters.Length;i++)
        {
            if(Username.EndsWith(Characters[i]))
            {
                EW = true;
                Debug.LogWarning("jjjjjjjj");
            }
        }
        if(SW == true && EW == true)
        {
            UsernameValid = true;
        }
        else
        {
            popuser.SetActive(true);
        }
    }
    void Passwordvalidation()
    {
        bool SP = false;
        bool EP = false;
        for (int i = 0; i < Characters.Length; i++)
        {
            if (Password.StartsWith(Characters[i]))
            {
                SP = true;
                Debug.LogWarning("p1");
            }
        }
        for (int i = 0; i < Characters.Length; i++)
        {
            if (Password.EndsWith(Characters[i]))
            {
                EP = true;
                Debug.LogWarning("p2");
            }
        }
        if (SP == true && EP == true)
        {
            PasswordValid = true;
        }
        else
        {
            poppass7.SetActive(true);
        }
    }
    void Birthvalidation()
    {
        bool SBD = false;
        bool SBM = false;
        bool SBY = false;
        bool EBD = false;
        bool EBM = false;
        bool EBY = false;
        for (int i = 0; i < number.Length; i++)
        {
            if (Birthday.StartsWith(number[i]))
            {
                SBD = true;
                Debug.LogWarning("dd1");
            }
            if (Birthmount.StartsWith(number[i]))
            {
                SBM = true;
                Debug.LogWarning("mm1");
            }
            if (Birthyear.StartsWith(number[i]))
            {
                SBY = true;
                Debug.LogWarning("yyyy1");
            }
        }
        for (int i = 0; i < number.Length; i++)
        {
            if (Birthday.EndsWith(number[i]))
            {
                EBD = true;
                Debug.LogWarning("dd2");
            }
            if (Birthmount.EndsWith(number[i]))
            {
                EBM = true;
                Debug.LogWarning("mm2");
            }
            if (Birthyear.EndsWith(number[i]))
            {
                EBY = true;
                Debug.LogWarning("yyyy2");
            }
        }
        if (SBD == true && SBM == true && SBY == true && EBD == true && EBM == true && EBY == true)
        {
            BirthValid = true;
        }
        else
        {
            popbirth9.SetActive(true);
        }
    }
}
