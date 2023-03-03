using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PulseLight : MonoBehaviour
{
  
    NoteHitEventManager hitEventManager;
    Animation animation;
    Color original;
    void Start()
    {
        hitEventManager = GameObject.FindGameObjectWithTag("NoteManager").GetComponent<NoteHitEventManager>();
        original = GetComponent<Light2D>().color;
        hitEventManager.OnNoteHit += (obj,time) =>
        {
            Color color = Random.ColorHSV();

            
            animation.Play();
        };


        

    }

    // Update is called once per frame
    void Update()
    {
       


    }



}
