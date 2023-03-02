using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INoteSource
{
    public Action<NoteObject> OnNextNote { get; set; } 
}
