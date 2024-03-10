using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(Collider2D))]
public class CelestialBodyBehavior : MonoBehaviour
{
    public static List<CelestialBodyBehavior> celestialBodyBehaviors;
    public Rigidbody2D rb;
    private const float gravitationalConstant = 1f;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() {
        celestialBodyBehaviors ??= new();
        celestialBodyBehaviors.Add(this);
    }

    private void OnDisable() {
        celestialBodyBehaviors.Remove(this);
    }


    private void FixedUpdate() {
        foreach(CelestialBodyBehavior cbb in celestialBodyBehaviors)
        {
            if(cbb != this)
            {
                Attract(cbb);
            }
        }
    }

    private void Attract(CelestialBodyBehavior obj){
        Rigidbody2D rbToAttract = obj.rb;

        UnityEngine.Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        float forceMagnitude = gravitationalConstant * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance,2);
        UnityEngine.Vector3 force = direction.normalized * forceMagnitude;
        
        rbToAttract.AddForce(force);
    }
}
