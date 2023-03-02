using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteReceiver : AbstractNoteGenerator
{

    SocketClient _networkEventClient;

    private void Awake()
    {
        _networkEventClient = GameObject.FindGameObjectWithTag("SocketClient").GetComponent<SocketClient>();
    }
    void Start()
    {
        _networkEventClient.OnNewNoteFromMaker += (noteData)=>
        {
            noteData.DELAY_BEFORE = 1.4f;
            noteData.DELAY_AFTER = 0.4f;
            GenerateNextNote(noteData);
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
