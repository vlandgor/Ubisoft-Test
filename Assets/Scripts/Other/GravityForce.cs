using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityForce : MonoBehaviour
{
	private HashSet<Rigidbody2D> affectedBodies = new HashSet<Rigidbody2D>();
	private Rigidbody2D rb;

	[Range(10, 50)]
	[SerializeField] private float _mass;

	[Range(10, 50)]
	[SerializeField] private float _gravity_scale;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.mass = _mass;
		rb.gravityScale = _gravity_scale;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Rocket" && other.attachedRigidbody != null)
		{
			affectedBodies.Add(other.attachedRigidbody);
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Rocket" && other.attachedRigidbody != null)
		{
			affectedBodies.Remove(other.attachedRigidbody);
		}
	}

	public void FixedUpdate()
	{
		foreach (Rigidbody2D body in affectedBodies)
		{
			Vector3 forceDirection = (new Vector2(transform.position.x, transform.position.y) - body.position).normalized;
			float distanceSqr = (new Vector2(transform.position.x, transform.position.y) - body.position).sqrMagnitude;
			float strength = rb.mass * body.mass / distanceSqr;

			body.AddForce(forceDirection * strength);
		}
	}
}
