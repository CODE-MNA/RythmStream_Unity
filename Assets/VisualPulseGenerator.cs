using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class VisualPulseGenerator : MonoBehaviour
{
    [SerializeField]
    ParticleSystem _pulseParticle;

    [SerializeField]
    Light2D _light;

    IConductor _conductor;

    [SerializeField]
    float max = 5;
    bool triggered = false;

    private void Awake()
    {
        _conductor = GameObject.FindGameObjectWithTag("Conductor").GetComponent<IConductor>();
        
    }
    void Start()
    {
        _conductor.SpawnNote += (posX,posY) =>
        {
            _pulseParticle.Stop();

            _light.intensity = max;

            triggered = true;

            _pulseParticle.Emit(1);
        };
    }


  
    // Update is called once per frame
    void Update()
    {
        if (!triggered) return;

        if(_light.intensity > 1)
        {
            _light.intensity -= 5 * Time.deltaTime;
        }
        else
        {
            triggered=false;
            _light.intensity = 1;
        }

    }
}
