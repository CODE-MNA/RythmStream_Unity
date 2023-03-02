using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Test Note Data")]
public class NoteObject : ScriptableObject
{

    
    public float posX;
    public float posY;
    public float noteTimeInSong;
    public int noteNumber;

    public float DELAY_BEFORE;
    public float DELAY_AFTER;


    public static NoteObject ParseFromJsonString(string json)
    {

        

        Dictionary<string, object> result = JsonConvert.DeserializeObject <Dictionary<string, object>>(json);
        float posX = float.Parse(result.GetValueOrDefault("posX").ToString());
        float posY = float.Parse(result.GetValueOrDefault("posY").ToString());
        float noteTimingInSong = float.Parse(result.GetValueOrDefault("noteTimeInSong").ToString());
        int noteNumber = int.Parse(result.GetValueOrDefault("noteNumber").ToString());


        NoteObject obj =  ScriptableObject.CreateInstance<NoteObject>();

        obj.posX = posX;
        obj.posY = posY;
        obj.noteTimeInSong = noteTimingInSong;
        obj.noteNumber = noteNumber;

        return obj;
    }

}
