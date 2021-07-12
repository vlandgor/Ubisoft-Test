using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStation
{
    State GetState();
}

public class PlayerControlRocketStation : MonoBehaviour, IStation
{
    private State state;

    [SerializeField]
    private HandleButton leftButton;
    [SerializeField]
    private HandleButton rightButton;

    

    private void FixedUpdate()
    {
        if (leftButton.isPressed)
            state = State.left;
        if (rightButton.isPressed)
            state = State.right;
        if (!leftButton.isPressed && !rightButton.isPressed)
            state = State.idle;
    }

    public State GetState()
    {
        return state;
    }
}
