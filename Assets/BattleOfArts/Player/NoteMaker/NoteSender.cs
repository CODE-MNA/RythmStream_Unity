using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSender : MonoBehaviour
{
    IConductor _conductor;
    SocketClient _socketClient;

    private void Awake()
    {
        _conductor = GameObject.FindGameObjectWithTag("Conductor").GetComponent<IConductor>();
        _socketClient = GameObject.FindGameObjectWithTag("SocketClient").GetComponent<SocketClient>();
    }

    void Start()
    {

        _conductor.SpawnNote += (a, b) => SendNote(a,b,_conductor.NoteNumber);

    }

    // Update is called once per frame
    void Update()
    {


    }

    private void SendNote(float posX,float posY, int noteNumber)
    {
      

        _socketClient.SendNoteDataToServer(posX, posY, noteNumber);

      
    }
}
