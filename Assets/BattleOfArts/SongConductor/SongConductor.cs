using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongConductor : MonoBehaviour, IConductor
{
    public int NoteNumber { get; set; }
    public Action<float,float> SpawnNote { get; set; }


    [SerializeField]
    AudioSource source;

  


    private void Start()
    {
        NoteNumber = 0;

        SpawnNote += (x, y) =>
        {
            NoteNumber++;
        };
        

    
    }

    public void StartAudio()
    {
       
        source.Play();
    }

    public float GetSongTime()
    {
        if(!source.isPlaying) return 0;
        return source.time;
    }

    public void StopAudio()
    {
        source.Stop();
    }
}
