using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{

    Queue<NoteObject> _noteQueue;
    IConductor _conductor;

  
    INoteSource _source;

    [SerializeField]
    GameObject _notePrefab;
    bool _paused;
    
    public float DELAY_BETWEEN_SPAWN_AND_HIT { get; private set; }

    private void Awake()
    {
        _source = GetComponent<INoteSource>();
        _conductor = GameObject.FindGameObjectWithTag("Conductor").GetComponent<IConductor>();

    }

    void Start()
    {
        
        _noteQueue = new Queue<NoteObject>();


        _paused = false;
        DELAY_BETWEEN_SPAWN_AND_HIT = 1f;

       SubscribeToSource();
       
    
    }

    void SubscribeToSource()
    {
        if (_source == null) return;

      

        _source.OnNextNote += (note) =>
        {
            print("note received");
            _noteQueue.Enqueue(note);
            _paused = false;

        };
    }



    // Update is called once per frame
    void Update()
    {

        if (_noteQueue == null || _paused) return;

        if(_noteQueue.Count <= 0)
        {
            PauseGame();
            _paused = true;
          
        }


        
        QueueCheckIfTiming();
        
    }

    private void PauseGame()
    {
        print("note ended for now");
    }

    private void EndGame()
    {

    }

    void QueueCheckIfTiming()
    {
        if(_paused) return;

        NoteObject note = _noteQueue.Peek();
            
            if (MathF.Abs(note.noteTimeInSong - (float)_conductor.GetSongTime()) < note.DELAY_BEFORE && _conductor.GetSongTime() > 0)
            {
                _notePrefab.GetComponent<SpawnedBeatNote>()._noteData = note;
                SpawnNoteBeat(_notePrefab,new Vector2(note.posX,note.posY));
                _noteQueue.Dequeue();
            }
      


       
    }


    void SpawnNoteBeat(GameObject beatPrefab, Vector2 spawnPos)
    {
        Vector3 position = new Vector3(spawnPos.x, spawnPos.y, 0);
        GameObject.Instantiate(beatPrefab, position,Quaternion.identity);

            

    }
}
