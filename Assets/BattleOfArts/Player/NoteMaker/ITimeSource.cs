using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITimeSource
{
    public List<float> GetTimes ();
}
