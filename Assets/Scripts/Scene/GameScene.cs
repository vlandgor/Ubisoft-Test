using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    public static GameScene Instance = null;

    public const int PLANETS_IN_SESSION = 5;
    public const int PLANET_BASE_HEALTH = 600;

    [SerializeField]
    private Planet _planetPrefab;

    [SerializeField]
    private PlanetHud _planetHUDPrefab;

    [SerializeField]
    private Transform _planetHUDParent;

    [SerializeField]
    private List<RocketObject> rocketsType = new List<RocketObject>();

    [SerializeField]
    private List<PlanetObject> planetsType = new List<PlanetObject>();

    public PlayerControlRocketStation pc;

    private List<Planet> planets = new List<Planet>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (GameManager.isNewScene)
            GameSession.StartGame();
        else
            GameSession.LoadGame();
    }

    public static void CreateScene() => Instance.CreateSceneInstance();
    private void CreateSceneInstance()
    {
        for (int i = 0; i < PLANETS_IN_SESSION; i++)
        {
            Planet planet = CreatePlanet(i, 600, planetsType[Random.Range(0, Instance.planetsType.Count)], rocketsType[Random.Range(0, Instance.rocketsType.Count)]);
            planet._planetMovement.SetStartPosition(i, PLANETS_IN_SESSION);
            planets.Add(planet);
        }
    }

    public static void ResetScene() => Instance.ResetSceneInstance();
    private void ResetSceneInstance()
    {
        foreach(Planet planet in planets)
        {
            Destroy(planet.gameObject);
        }
    }


    public static void LoadScene(SceneData data) => Instance.LoadSceneInstance(data);
    private void LoadSceneInstance(SceneData data)
    {
        for(int i = 0; i < data.planetsData.Count; i++)
        {
            Planet planet = CreatePlanet(i, data.planetsData[i].health, data.planetsData[i].planetObject, data.planetsData[i].rocketObject);
            planet._planetMovement.SetStartPosition(i, PLANETS_IN_SESSION);
            planets.Add(planet);
        }
    }

    private Planet CreatePlanet(int index, int planetHealth, PlanetObject planetType, RocketObject rocketType)
    {
        Planet planet = Instantiate(_planetPrefab);
        planet.SetPlanet(planetHealth, planetType, rocketType);
        if (index == 0)
            planet.GetComponentInChildren<ControlRocketStation>().controller = pc;
        else
            planet.GetComponentInChildren<ControlRocketStation>().controller = planet.GetComponent<AIControlRocketStation>();

        PlanetHud hud = Instantiate(_planetHUDPrefab, _planetHUDParent);
        hud.SetPlanet(planet, planetType);

        return planet;
    }

    public static List<Planet> GetPlanetsList() => Instance.planets;
}
