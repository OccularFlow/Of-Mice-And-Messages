using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaballParticleClass : MonoBehaviour {
	Rigidbody2D rb;
	TrailRenderer tr;

	void OnEnable() {
		Invoke ("destroy", 90f);
		tr.Clear();
	}

	void destroy() {
		if (tag == "message bottle") {
            DropletPool.instance.bottleLost();
		}
		gameObject.SetActive(false);
	}

	void OnDisable() {
		CancelInvoke();
	}
	void Awake () {
		rb = GetComponent<Rigidbody2D> ();
		tr = GetComponent<TrailRenderer>();
	}

	void FixedUpdate () {
		VelocityLimiter ();
    }


    void VelocityLimiter()
	{
		Vector2 vel = rb.velocity;
		if (vel.y < -8f) {
			vel.y = -8f;
		}
		if (vel.x > 0) {
			vel.x = vel.x - Time.deltaTime*2.75f;
		}
		if (vel.x < 0) {
			vel.x = vel.x + Time.deltaTime*2.75f;
		}
		rb.velocity = vel;
	}
}
