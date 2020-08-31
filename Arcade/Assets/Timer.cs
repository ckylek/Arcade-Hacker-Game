using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeLeft = 10.0f;
    public string startText;
    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        // startText.text = (timeLeft).ToString("0");
        if (timeLeft < 0)
        {

        }
        
    }
}
