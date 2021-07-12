using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SceneData
{
    public List<PlanetData> planetsData = new List<PlanetData>();

    public SceneData(List<PlanetData> planetsData)
    {
        this.planetsData = planetsData;
    }
}
