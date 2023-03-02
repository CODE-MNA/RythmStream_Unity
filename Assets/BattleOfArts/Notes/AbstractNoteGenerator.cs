using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractNoteGenerator : MonoBehaviour, INoteSource
{
    public Action<NoteObject> OnNextNote { get ; set; }

    public virtual void GenerateNextNote(NoteObject note)
    {
      
        OnNextNote?.Invoke(note);
    }
}
