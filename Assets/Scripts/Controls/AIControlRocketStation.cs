using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControlRocketStation : MonoBehaviour, IStation
{
    private State state;

    private IEnumerator Start()
    {
        while (true)
        {
            state = (State)Random.Range(0, 3);
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }

    public State GetState()
    {
        return state;
    }
}
