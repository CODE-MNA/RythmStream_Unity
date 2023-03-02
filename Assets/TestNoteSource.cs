using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNoteSource : AbstractNoteGenerator
{
    

    float DELAY_BETWEEN_SPAWN_AND_HIT = 1f;

    float timea = 0.3f;
    bool triggered = false;

    List<NoteObject> sourceNotes = new List<NoteObject>();

    void Awake()
    {
        NoteObject n1 = ScriptableObject.CreateInstance<NoteObject>();
        NoteObject n2 = ScriptableObject.CreateInstance<NoteObject>();
        NoteObject n3 = ScriptableObject.CreateInstance<NoteObject>();

        n1.noteNumber = 0;
        n2.noteNumber = 1;
        n3.noteNumber = 2;

        n1.posX = -3;
        n2.posX = 4;
        n3.posX = 5;

        n1.posY = -1;
        n2.posY = 3;
        n3.posY = -3;

        n1.noteTimeInSong = 4f;
        n2.noteTimeInSong = 7f;
        n3.noteTimeInSong = 11.4f;


        n1.DELAY_BEFORE = DELAY_BETWEEN_SPAWN_AND_HIT + 1;
        n1.DELAY_AFTER = DELAY_BETWEEN_SPAWN_AND_HIT / 2;

        n2.DELAY_BEFORE = DELAY_BETWEEN_SPAWN_AND_HIT;
        n2.DELAY_AFTER = DELAY_BETWEEN_SPAWN_AND_HIT / 2;
        n3.DELAY_BEFORE = DELAY_BETWEEN_SPAWN_AND_HIT;
        n3.DELAY_AFTER = DELAY_BETWEEN_SPAWN_AND_HIT / 2;

        sourceNotes.Add(n1);
        sourceNotes.Add(n2);
        sourceNotes.Add(n3);
      
    }

    void TestGenerateNotes(List<NoteObject> notes)
    {
        foreach (var item in notes)
        {
            GenerateNextNote(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered) return;

        timea -= Time.deltaTime;

        if(timea < 0)
        {

            TestGenerateNotes(sourceNotes);
            triggered = true;
        }
    }
}
