using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimesReceiver : MonoBehaviour
{

    List<float> _timings;
    SocketClient _networkClient;

    private void Awake()
    {
        _networkClient = GameObject.FindGameObjectWithTag("SocketClient").GetComponent<SocketClient>();
    }

    void Start()
    {
        _timings = new List<float>();

        _networkClient.OnReceivedTimings += (times) =>
        {
            foreach (var item in times)
            {
                _timings.Add(item);
            }

        };

        _networkClient.GetTimingRequest("Endgame");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
