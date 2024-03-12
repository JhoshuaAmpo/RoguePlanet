using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CelestialBodyBehavior))]
public class SunBehavior : MonoBehaviour
{
    [SerializeField] float XScalar;
    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate() {
        rb.AddForce(XScalar * transform.right,ForceMode2D.Force);
    }
}
