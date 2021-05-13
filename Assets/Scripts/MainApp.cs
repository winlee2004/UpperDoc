using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainApp : MonoBehaviour
{
    public Text Name;
    public string[] Lines;
    public string user;
    public string namesur;
    void Start()
    {
        Debug.LogWarning(PlayerPrefs.GetString("user"));
        user = PlayerPrefs.GetString("user");
        string path = Application.persistentDataPath + "/" + user + ".txt";
        Lines = System.IO.File.ReadAllLines(path);
        namesur = Lines[2];
        Name.text = "คุณ "+namesur;
    }
    public void LoadScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
    void Update()
    {
        
    }
}
