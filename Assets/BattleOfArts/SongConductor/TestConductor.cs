using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestConductor : MonoBehaviour, IConductor
{
    bool roundStarted;

    [SerializeField]
    float delayBetweenTicks = 4f;

    float currentTime;




    public Action<float,float> SpawnNote { get ; set; }
    public int NoteNumber { get ; set; }

    public float GetSongTime()
    {
        return Time.timeSinceLevelLoad;
    }

    void Start()
    {
        currentTime = delayBetweenTicks;

    }

    // Update is called once per frame
    void Update()
    {
      

        if(currentTime > 0 )
        {
            currentTime -= Time.deltaTime;
        }
        else
        {
            //TRIGGER EVENT

 
            currentTime = delayBetweenTicks;

        }
    }
}
