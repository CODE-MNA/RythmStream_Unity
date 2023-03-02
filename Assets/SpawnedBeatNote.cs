using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedBeatNote : MonoBehaviour
{
    public NoteObject _noteData;
    public IConductor _conductor;

    [SerializeField]
    GameObject _circleIndicator;

    [SerializeField]
    SpriteController _spriteController;

     bool _reachedCritical = false;
     bool _isHit = false;

    Vector3 _startingIndicatorScale;
    Vector3 _endingIndicatorScale;
    float _startTime;




    void Start()
    {
        _conductor = GameObject.FindGameObjectWithTag("Conductor").GetComponent<IConductor>();

        _startingIndicatorScale = _circleIndicator.transform.localScale;

        _endingIndicatorScale = Vector3.one;


        _startTime = _conductor.GetSongTime();
    }

    

    float InterpolateScale(float startTime,float currentSongTime, float targetTime)
    {
        float numerator = currentSongTime - startTime;
        float denominator = targetTime - startTime;

       return Mathf.Clamp01(numerator / denominator);
    }

    void Update()
    {
        if (_noteData == null) return;

        if (_reachedCritical)
        {
            return;
        };

        float interpolationValue = InterpolateScale(_startTime, _conductor.GetSongTime(), _noteData.noteTimeInSong);

      _circleIndicator.transform.localScale = Vector3.Lerp(_startingIndicatorScale, _endingIndicatorScale,interpolationValue);

        _spriteController.SetAlpha(interpolationValue); 


        if (ChangedToCritical())
        {
           
            _reachedCritical = true;
            _spriteController.ChangeSpriteToCriticalState();

            //Critical End

            Invoke(nameof(EndCritical), 0.2f);

            Invoke(nameof(EndNote), _noteData.DELAY_AFTER);

        }

    }

    public void PerformHit()
    {
        if (_isHit == true) return;

        _isHit = true;
        print("hit! please fire of an event");
    }

    void EndNote()
    {
        Destroy(gameObject);
    }
    
    void EndCritical()
    {
        _spriteController.ChangeSpriteToNormal();
    }

    bool ChangedToCritical()
    {
        

        if(_conductor.GetSongTime() == _noteData.noteTimeInSong)
        {
            
            return true;
        }

        if(Mathf.Abs(_conductor.GetSongTime()  - _noteData.noteTimeInSong) < 0.2f)
        {
            return true;
        }


       
        return false;
    }
}