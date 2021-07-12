using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetHud : MonoBehaviour
{
    private Planet _planet;

    [SerializeField]
    private Image _planetIcon;

    [SerializeField]
    private Slider _healthBar;

    [SerializeField]
    private Slider _fireCooldown;

    private void Start()
    {
        _planet.OnPlanetStateChange += ChangeHealth;

        _healthBar.maxValue = GameScene.PLANET_BASE_HEALTH;
        _fireCooldown.maxValue = _planet._rocketStation._cooldown;
    }

    private void FixedUpdate()
    {
        ChangeCooldown();
    }

    public void SetPlanet(Planet planet, PlanetObject planetObject)
    {
        _planet = planet;
        _planetIcon.sprite = planetObject.type;
    }

    private void ChangeHealth(int health)
    {
        if (health <= 0) Destroy(gameObject);
        _healthBar.value = health;
    }
    private void ChangeCooldown()
    {
        _fireCooldown.value = _planet._rocketStation.nextFire;
    }

}
