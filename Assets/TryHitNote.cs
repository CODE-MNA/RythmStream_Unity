using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryHitNote : MonoBehaviour
{

    SpawnedBeatNote _hoveringNote;

    [SerializeField]
    SpriteRenderer _spriteRenderer;


    Animation animation;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {




        

        if(Input.GetMouseButtonDown(0))
        {
            if(_hoveringNote != null)
            {
                VisualizeHit(true);
                _hoveringNote.PerformHit();
            }
            else
            {
                VisualizeHit(false);
            }

        }

    }

    public void VisualizeHit(bool success)
    {
        if (success)
        {
            animation.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        //Collider is the note we hit
        if(collider.TryGetComponent<SpawnedBeatNote>(out SpawnedBeatNote beatNote)){
            print("hovered note " + beatNote._noteData.noteNumber);
            _hoveringNote = beatNote;
        }
    }


    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform")) return;


        print("noteexit");
        _hoveringNote = null;
    }
}
