using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMovement : MonoBehaviour
{
    private int orbit_radius = 4;

    private float angular_speed = 0.5f;

    private float angle = 0f;

    public void SetStartPosition(int value, int count)
    {
        angle = (2 * Mathf.PI / count) * value;
    }
    
    private void FixedUpdate()
    {
        TrajectoryMovement();
    }

    private void TrajectoryMovement()
    {
        transform.localPosition = new Vector3(Mathf.Cos(angle) * orbit_radius * 1.9f, Mathf.Sin(angle) * orbit_radius);
        angle = angle + Time.fixedDeltaTime * angular_speed;
        if (angle > 360) angle = 0;
    }
}
