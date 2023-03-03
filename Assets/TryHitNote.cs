using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryHitNote : MonoBehaviour
{

    SpawnedBeatNote _hoveringNote;

    [SerializeField]
    SpriteRenderer _spriteRenderer;

    [SerializeField]
    Animation _successAnimation;

    [SerializeField]
    GameObject _destroyEffect;


    Rigidbody2D _rb;
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _rb.angularVelocity = 5;

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

                GameObject.Instantiate(_destroyEffect, transform.position, Quaternion.identity);

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
            _successAnimation.Play("Success");

            _rb.AddTorque(40);

            Invoke(nameof(CancelTorque), 3);
           
        }
        else
        {

        }
        
        
    }

    void CancelTorque()
    {
        _rb.angularVelocity = _rb.angularVelocity / 2;

        if(_rb.angularVelocity < 40)
        {
            _rb.angularVelocity = 30;
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
