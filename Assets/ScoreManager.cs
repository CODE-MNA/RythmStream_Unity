using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{

    public UnityAction<float> OnScoreChange;
    NoteHitEventManager noteHitEventManager;

    public int Score;

    int combo = 0;


    void Start()
    {
        Score = 0;

        noteHitEventManager = GameObject.FindGameObjectWithTag("NoteManager").GetComponent<NoteHitEventManager>();

        noteHitEventManager.OnNoteHit += (NoteObject obj, float time) =>
        {
           int score = (int)CalculateScore(obj.noteTimeInSong, time,obj.DELAY_BEFORE);
            
            print(obj.noteTimeInSong - time);
            if(score > 0)
            {
                AddScore(score);
            }
        };
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    float CalculateScore(float expectedNoteTime, float timeWhenHit, float freeRange)
    {
        if(Mathf.Abs(expectedNoteTime - timeWhenHit) < 0.06f)
        {
            return 500;
        }
        else
        {

            float diff = Mathf.Abs(expectedNoteTime - timeWhenHit);

            float final = (500 - (1000 * (diff /freeRange)));

            int bonus = combo * 50;

            if(final < 250)
            {
                combo = 0;
                return 0;
            }
            return final + bonus;
        }
    }


    public void AddScore(int score)
    {
        Score += score;

       combo++;

        OnScoreChange?.Invoke(score);
    }

}
