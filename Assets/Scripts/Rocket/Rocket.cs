using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Rocket : MonoBehaviour
{
    public int damage = 150;

    private float speed = 10;

    private float live_time = 10f;

    private void Start()
    {
        Destroy(gameObject, live_time);
    }

    void FixedUpdate()
    {
        transform.Translate(0, speed * Time.fixedDeltaTime, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Planet")
        {
            collision.transform.GetComponent<Planet>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if(collision.collider.tag == "Sun")
        {
            transform.position = new Vector3(500, 500, 500);
            Destroy(gameObject, 1f);
        }
    }

    public void SetStats(RocketObject rocketObject)
    {
        damage = rocketObject._damage;
        speed = rocketObject._speed;
    }
}
