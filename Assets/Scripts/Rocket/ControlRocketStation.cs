using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRocketStation : MonoBehaviour
{
    public IStation controller;

    public State _stationState { get; set; }

    private const int rotate_speed = 150;

    private void FixedUpdate()
    {
        Rotate();
    }

    private void Rotate()
    {
        if (controller.GetState() == State.right)
            transform.Rotate(Vector3.back * rotate_speed * Time.fixedDeltaTime);
        else if (controller.GetState() == State.left)
            transform.Rotate(Vector3.forward * rotate_speed * Time.fixedDeltaTime);
        else if (controller.GetState() == State.idle)
            return;
    }
}
