using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoundEventManager : MonoBehaviour
{


    public UnityEvent RoundStart;

    public RoundState state;

    public Action RoundEnd { get; private set; }


    public void StartRound()
    {
        RoundStart?.Invoke();
        state = RoundState.Started;
    }
    public void EndRound()
    {
        RoundEnd?.Invoke();
        state = RoundState.Ended;
    }


    SocketClient _networkClient;

    private void Awake()
    {
        try
        {

        _networkClient = GameObject.FindGameObjectWithTag("SocketClient").GetComponent<SocketClient>();
        _networkClient.OnPlayingRoundStart += StartRound;

        }catch (Exception ex)
        {
            print("PLAYING WITHOUT NETWORKING");
        }

         state = RoundState.WaitingToStart;


    }



    public enum RoundState
    {
        WaitingToStart,
        Started,
        Ended
    }

}
