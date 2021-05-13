using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public bool isFlat = true;
    private Rigidbody rigid;
    public float speed = 5000f;
    public int points = 0;
    public Text Score;
    public Text TotalScore;
    //private void Start()
    //{
    //    rigid = GetComponent<Rigidbody>();
    //}

    //private void Update()
    //{
    //    Vector3 tilt = Input.acceleration;
    //    Score.text = "SCORE : " + points;
    //    if (isFlat)
    //    {
    //        tilt = Quaternion.Euler(90, 0, 0) * tilt;
    //    }

    //    rigid.AddForce(tilt*speed);
    //    Debug.DrawRay(transform.position, tilt, Color.cyan);

    //    //transform.Translate(Input.acceleration.x, tilt, -Input.acceleration.z);
    //}
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "HardStar")
        {
            Destroy(col.gameObject);
            points++;
        }
    }
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Main()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
    private void FixedUpdate()
    {


        Score.text = "SCORE : " + points;
        
        Vector3 movement = new Vector3(Input.acceleration.x, Input.acceleration.y, Input.acceleration.z);
        if (isFlat)
        {
            movement = Quaternion.Euler(90, 0, 0) * movement;
        }
        rigid.AddForce(movement * speed * Time.deltaTime);
        TotalScore.text = points.ToString();
    }
}
