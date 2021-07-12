using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Rocket", menuName = "Objects/Rocket", order = 1)]
[System.Serializable]
public class RocketObject : ScriptableObject
{
    [Range(150, 200)]
    public int _damage;

    [Range(1f, 2f)]
    public float _cooldown;

    [Range(5, 10)]
    public float _speed;

    [Range(1, 10)]
    public float _weight;
}
