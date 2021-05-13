using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class PsFormApp : MonoBehaviour
{
    public GameObject main;
    public GameObject one;
    public GameObject two;
    public GameObject tree;
    public GameObject four;
    public GameObject five;
    public GameObject play;
    public GameObject pause;
    public RawImage oneIm;
    public VideoPlayer onevd;
    public string user;
    private string time = System.DateTime.UtcNow.ToLocalTime().ToString("d-M-yyyy");
    void Start()
    {
        onevd.Pause();
    }
    public void LoadScene(string scenename)
    {
        
        SceneManager.LoadScene(scenename);
    }
    public void GamePlay1()
    {            
            SceneManager.LoadScene("GameOne");
            PlayerPrefs.SetString("game", "1");       
    }
    public void GamePlay2()
    {

            PlayerPrefs.SetString("game", "2");
            SceneManager.LoadScene("GameTwo");

    }
    public void GamePlay3()
    {
            PlayerPrefs.SetString("game", "3");
            SceneManager.LoadScene("GameThree");
    }
    public void GamePlay4()
    {
            PlayerPrefs.SetString("game", "4");
            SceneManager.LoadScene("GameFour");
    }
    public void GamePlay5()
    {
            PlayerPrefs.SetString("game", "5");
            SceneManager.LoadScene("GameFive");
    }
    public void GamePlay6()
    {
        SceneManager.LoadScene("GameOne");
        PlayerPrefs.SetString("game", "6");
    }
    public void GamePlay7()
    {

        PlayerPrefs.SetString("game", "7");
        SceneManager.LoadScene("GameTwo");

    }
    public void GamePlay8()
    {
        PlayerPrefs.SetString("game", "8");
        SceneManager.LoadScene("GameThree");
    }
    public void GamePlay9()
    {
        PlayerPrefs.SetString("game", "9");
        SceneManager.LoadScene("GameFour");
    }
    public void GamePlay10()
    {
        PlayerPrefs.SetString("game", "10");
        SceneManager.LoadScene("GameFive");
    }
    public void play1()
    {
        onevd.Play();
        play.SetActive(false);
        pause.SetActive(true);
    }
    public void pause1()
    {
        onevd.Pause();
        play.SetActive(true);
        pause.SetActive(false);
    }
    public void OneClick()
    {
        one.SetActive(true);
        main.SetActive(false);
        //StartCoroutine(playonevd());
        oneIm.texture = onevd.texture;
        //onevd.Play();
    }
    public void TwoClick()
    {
        two.SetActive(true);
        main.SetActive(false);
    }
    public void TreeClick()
    {
        tree.SetActive(true);
        main.SetActive(false);
    }
    public void FourClick()
    {
        four.SetActive(true);
        main.SetActive(false);
    }
    public void FiveClick()
    {
        five.SetActive(true);
        main.SetActive(false);
    }
    public void ClosePop()
    {
        main.SetActive(true);
        one.SetActive(false);
        two.SetActive(false);
        tree.SetActive(false);
        four.SetActive(false);
        five.SetActive(false);
        //onevd.Pause();
    }
    //IEnumerator playonevd()
    //{
    //    onevd.Prepare();
    //    WaitForSeconds waitForSeconds = new WaitForSeconds(1);
    //    while (onevd.isPrepared)
    //    {
    //        yield return waitForSeconds;
    //        break;
    //    }
    //    oneIm.texture = onevd.texture;
    //    onevd.Play();
    //}
}
