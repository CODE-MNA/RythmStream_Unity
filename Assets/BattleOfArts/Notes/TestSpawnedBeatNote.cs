using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawnedBeatNote : MonoBehaviour
{
    public NoteObject _noteData;
    public IConductor _conductor;

    public float spawnTime;

    [SerializeField]
    GameObject _circleIndicator;

    [SerializeField]
    SpriteController _spriteController;

     bool _reachedCritical = false;
     bool _isHit = false;
    bool _ending = false;


    Vector3 _startingIndicatorScale;
    Vector3 _endingIndicatorScale;
    float _startTime;

    NoteHitEventManager _eventManager;

    


    void Start()
    {
        _conductor = GameObject.FindGameObjectWithTag("Conductor").GetComponent<IConductor>();
        _eventManager = GameObject.FindGameObjectWithTag("NoteManager").GetComponent<NoteHitEventManager>();

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

        if (_ending)
        {
          transform.localScale =  Vector3.MoveTowards(transform.localScale, Vector3.zero, 5 * Time.deltaTime);


            return;
        };

        float interpolationValue = InterpolateScale(_startTime, _conductor.GetSongTime(), spawnTime);

      _circleIndicator.transform.localScale = Vector3.Lerp(_startingIndicatorScale, _endingIndicatorScale,interpolationValue);

        _spriteController.SetAlpha(interpolationValue + 0.2f); 


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
        _ending = true;

        _eventManager.OnNoteHit?.Invoke(_noteData,_conductor.GetSongTime());
        _circleIndicator.SetActive(false);
        

    }

    void EndNote()
    {
        
        Destroy(gameObject,1f);
    }
    
    void EndCritical()
    {
        _ending = true;
        _spriteController.ChangeSpriteToNormal();
    }

    bool ChangedToCritical()
    {
        

        if(_conductor.GetSongTime() == spawnTime)
        {
            
            return true;
        }

        if(Mathf.Abs(_conductor.GetSongTime()  - spawnTime) < 0.2f)
        {
            return true;
        }


       
        return false;
    }
}
