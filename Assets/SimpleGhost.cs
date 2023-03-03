using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGhost : MonoBehaviour
{

    SocketClient client;

    float xTarget;
    float yTarget;

    float movingTime;

    Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        client = GameObject.FindGameObjectWithTag("SocketClient").GetComponent<SocketClient>();


        client.OnNewNoteFromMaker += (note) =>
        {
            targetPos = new Vector3(xTarget, yTarget, 0);
        };

    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(transform.position.sqrMagnitude - targetPos.sqrMagnitude) < 0.1f)
        {
            print("close");
           movingTime = 0;

            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPos, 2 * movingTime * Time.deltaTime);

        movingTime += Time.deltaTime;
    }
}
