using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualPulseGenerator : MonoBehaviour
{
    [SerializeField]
    ParticleSystem _pulseParticle;

    IConductor _conductor;


    private void Awake()
    {
        _conductor = GameObject.FindGameObjectWithTag("Conductor").GetComponent<IConductor>();
    }
    void Start()
    {
        _conductor.SpawnNote += (posX,posY) =>
        {
            _pulseParticle.Stop();
            
            _pulseParticle.Emit(1);
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
