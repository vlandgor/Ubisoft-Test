using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Planet", menuName = "Objects/Planet", order = 1)]
[System.Serializable]
public class PlanetObject : ScriptableObject
{
    public Sprite type;
}
