using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class Planet : MonoBehaviour
{
    public RocketStation _rocketStation;
    public PlanetMovement _planetMovement;

    public delegate void PlanetStateChange(int health);
    public event PlanetStateChange OnPlanetStateChange;

    public PlanetObject planetObject { get; private set; }
    public RocketObject rocketObject { get; private set; }

    [Header("Variables")]
    [SerializeField]
    private SpriteRenderer _planetIcon;

    //Properties
    public int planet_health = GameScene.PLANET_BASE_HEALTH;

    private void Start()
    {
        OnPlanetStateChange?.Invoke(planet_health);
    }

    public void SetPlanet(int planetHealth, PlanetObject planetObject, RocketObject rocketObject)
    {
        planet_health = planetHealth;
        _rocketStation.SetRocketStation(rocketObject);
        OnPlanetStateChange?.Invoke(planet_health);
        _planetIcon.sprite = planetObject.type;
        this.planetObject = planetObject;
        this.rocketObject = rocketObject;
    }

    public void TakeDamage(int damage)
    {
        planet_health -= damage;
        OnPlanetStateChange?.Invoke(planet_health);
        if (planet_health <= 0)
        {
            OnPlanetStateChange?.Invoke(planet_health);
            Destroy(gameObject);
        }
        _rocketStation.CooldownReset();
    }

    public int GetPlanetHealth()
    {
        return planet_health;
    }
}
