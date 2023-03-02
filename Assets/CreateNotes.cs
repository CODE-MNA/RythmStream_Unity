using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNotes : MonoBehaviour
{
    
    


    IConductor _conductor;


 
    List<float> _times;
    SocketClient _networkClient;

    private void Awake()
    {
        _networkClient = GameObject.FindGameObjectWithTag("SocketClient").GetComponent<SocketClient>();
        _conductor = GameObject.FindGameObjectWithTag("Conductor").GetComponent<IConductor>();

    }

    void Start()
    {
        _times = new List<float>();

        _networkClient.OnReceivedTimings += (times) =>
        {
            foreach (var item in times)
            {
                _times.Add(item);
            }

            _times.Sort();


        };

        _networkClient.GetTimingRequest("Endgame");
    }


  


 

    // Update is called once per frame
    void Update()
    {


        if (_times.Count <= 0) return;


        if (MathF.Abs(_times[0] - (float)_conductor.GetSongTime()) < 0.04f && _conductor.GetSongTime() > 0)
        {
            print(_times[0]);
            _conductor.SpawnNote?.Invoke(transform.position.x, transform.position.y);
            _times.RemoveAt(0);

        }


    }

 
}
