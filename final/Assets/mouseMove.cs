using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseMove : MonoBehaviour
{

    public Transform player;
    public Transform pivot;
    public float camSpeed;
    public Vector3 camPos;
    public Vector3 camShift;

    private void Start()
    {
        camPos = player.position - transform.position;
        camSpeed = 2;
        pivot.transform.position = player.transform.position;
        pivot.transform.parent = player.transform;

       // Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {

        //find x pose and rotate target
        float xAxis = Input.GetAxis("Mouse X") * camSpeed;
        player.Rotate(0, xAxis, 0);
        // find y pose and rotate camera around target
        float yAxis = Input.GetAxis("Mouse Y") * camSpeed;
        pivot.Rotate(yAxis, 0, 0);

        //store rotations
        float yAngle = player.eulerAngles.y;
        float xAngle = pivot.eulerAngles.x;

        Quaternion camRot = Quaternion.Euler(-xAngle, yAngle, 0);
        transform.position = player.position - (camRot * camPos);

        
        if (transform.position.y < 1)
        {
            transform.position = new Vector3(transform.position.x,
                                             1,
                                             transform.position.z);
        }
        

        //transform.position = player.position - camPos;
        transform.LookAt(player.position); // + Vector3.up);

    }
}
