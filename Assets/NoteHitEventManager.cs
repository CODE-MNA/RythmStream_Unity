using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteHitEventManager : MonoBehaviour
{
    public Action<NoteObject, float> OnNoteHit;
    void Start()
    {
        OnNoteHit += (NoteObje, isn) =>
        {
            print("EVENT ");
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
