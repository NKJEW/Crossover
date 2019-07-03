using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {
    Rigidbody2D rb;

    void Start() {
        rb.centerOfMass = new Vector2(0, -0.5f);
    }

}
