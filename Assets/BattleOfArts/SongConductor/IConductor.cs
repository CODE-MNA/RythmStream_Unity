using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConductor
{

    int NoteNumber { get; set; }


    public Action<float,float> SpawnNote { get; set; }

    public float GetSongTime();
}
