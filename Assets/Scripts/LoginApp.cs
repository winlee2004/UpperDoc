using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class LoginApp : MonoBehaviour
{
    public void LoadScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public GameObject username;
    public GameObject password;
    public GameObject popusernull;
    public GameObject poppasswordnull;
    public GameObject popuser;
    public GameObject poppass7;
    private string Username;
    private string Password;
    private string[] Lines;
    private string DecryptedPass;
    public string nameuser;
    private bool UsernameValid = false;
    private bool PasswordValid = false;

    private string[] Characters = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
                                   "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
                                   "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "@", "!", "#", "%", "&", "_", "-", ".", "/", "+", "*",};
    private string[] number = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

    void Start()
    {
        
    }
    public void LoginButton()
    {
        string path = Application.persistentDataPath + "/" + Username + ".txt";
        bool UN = false;
        bool PW = false;
        if (Username != "")
        {
            Usernamevalidation();
            if (File.Exists(path) && UsernameValid == true)
            {
                UN = true;
                Lines = File.ReadAllLines(path);
                nameuser = Username;
                if (Password != "")
                {
                    Passwordvalidation();
                    if (File.Exists(path) && PasswordValid == true)
                    {
                        int i = 1;
                        foreach (char c in Lines[1])
                        {
                            i++;
                            char Decrypted = (char)(c / i);
                            DecryptedPass += Decrypted.ToString();
                        }
                        if (Password == DecryptedPass)
                        {
                            PW = true;
                        }
                        else
                        {
                            poppasswordnull.SetActive(true);
                            DecryptedPass = null;
                            Debug.LogWarning("Password Is Invalid1");
                        }
                    }
                    else
                    {
                        poppasswordnull.SetActive(true);
                        Debug.LogWarning("Password Is Invalid2");
                    }
                }
                else
                {
                    Debug.LogWarning("Password Field Empty");
                }
            }
            else
            {
                popusernull.SetActive(true);
                Debug.LogWarning("Username Is Invalid");
            }
        }
        else
        {
            Debug.LogWarning("Username Field Empty");
        }
        
        if (UN = true && PW == true)
        {
            username.GetComponent<InputField>().text = "";
            password.GetComponent<InputField>().text = "";
            Debug.LogWarning("Login Sucessful");
            PlayerPrefs.SetString("user", nameuser);
            Application.LoadLevel("Main");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Username != "" && Password != "")
            {
                LoginButton();
            }
        }
        Username = username.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
    }
    public void clousepop()
    {
        poppass7.SetActive(false);
        poppasswordnull.SetActive(false);
        popuser.SetActive(false);
        popusernull.SetActive(false);
    }
    void Usernamevalidation()
    {
        bool SW = false;
        bool EW = false;
        for (int i = 0; i < Characters.Length; i++)
        {
            if (Username.StartsWith(Characters[i]))
            {
                SW = true;
                Debug.LogWarning("kkkkkkkk");
            }
        }
        for (int i = 0; i < Characters.Length; i++)
        {
            if (Username.EndsWith(Characters[i]))
            {
                EW = true;
                Debug.LogWarning("jjjjjjjj");
            }
        }
        if (SW == true && EW == true)
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
}
