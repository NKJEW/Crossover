using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {
    public int damage;

    GameObject owner;

    public void Init (GameObject owner) {
        this.owner = owner;
    }

    void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject == owner)
            return;

        if (coll.gameObject.tag == "Player") {
            coll.gameObject.GetComponent<HealthController>().TakeDamage(damage, (Vector2)transform.position);
        }
    }
}
