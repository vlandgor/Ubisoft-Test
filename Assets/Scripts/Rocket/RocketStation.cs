using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketStation : MonoBehaviour
{
    public RocketObject _rocketObject;

    [SerializeField]
    private Rocket _rocketPrefab;

    [SerializeField]
    private Transform _firePoint;

    public float _cooldown;

    public float nextFire { get; private set; }

    private void Awake()
    {
        nextFire = 0;
    }

    private void FixedUpdate()
    {
        Shoot();
    }

    public void SetRocketStation(RocketObject rocketObject)
    {
        _rocketObject = rocketObject;
        _cooldown = rocketObject._cooldown;
    }

    private void Shoot()
    {
        nextFire += Time.fixedDeltaTime;
        if (nextFire > _cooldown)
        {
            nextFire = Time.fixedTime + _cooldown;
            Rocket rocket = Instantiate(_rocketPrefab, _firePoint.transform.position, transform.rotation);
            rocket.SetStats(_rocketObject);
            nextFire = 0;
        }
    }

    public void CooldownReset()
    {
        nextFire = 0;
    }
}
