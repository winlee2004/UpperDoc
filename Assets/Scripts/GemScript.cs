using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        transform.Rotate(0, 0, 90 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "player")
        {
            Destroy(gameObject);
            other.GetComponent<Game>().points++; //ส่งค่าข้ามไฟล์
        }
    }
}
