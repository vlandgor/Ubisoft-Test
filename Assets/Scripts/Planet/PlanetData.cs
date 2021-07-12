using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlanetData
{
    public int health;
    public PlanetObject planetObject;
    public RocketObject rocketObject;

    public PlanetData(Planet planet)
    {
        health = planet.GetPlanetHealth();
        planetObject = planet.planetObject;
        rocketObject = planet.rocketObject;
    }
}
