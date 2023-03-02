using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceToStart : MonoBehaviour
{
    [SerializeField]
    RoundEventManager _manager;

    
    void Start()
    {
        
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _manager.StartRound();
        }
    }
}
