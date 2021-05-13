using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultApp : MonoBehaviour
{
    public GameObject results;
    public GameObject kumnuns;
    public GameObject sums;
    void Start()
    {
        
    }
    public void ClickKumnun()
    {
        kumnuns.SetActive(true);
        results.SetActive(false);
    }
    public void ReturnClick()
    {
        results.SetActive(true);
        kumnuns.SetActive(false);       
    }
    public void ClickSum()
    {
        sums.SetActive(true);
        results.SetActive(false);
    }
    public void ClickDay(string scene)
    {
        PlayerPrefs.SetString("graph", "day");
        SceneManager.LoadScene(scene);
    }
    public void ClickMount(string scene)
    {
        PlayerPrefs.SetString("graph", "mount");
        SceneManager.LoadScene(scene);
    }
    public void ClickYear(string scene)
    {
        PlayerPrefs.SetString("graph", "year");
        SceneManager.LoadScene(scene);
    }
    public void LoadScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
    void Update()
    {
        
    }
}
