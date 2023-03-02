using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePlayerMovement : MonoBehaviour
{

    Camera _cam;

    void Start()
    {
        _cam = Camera.main;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = _cam.ScreenToWorldPoint(Input.mousePosition);
        transform.localPosition = new Vector3(pos.x,pos.y,transform.localPosition.z) ;
    }
}
