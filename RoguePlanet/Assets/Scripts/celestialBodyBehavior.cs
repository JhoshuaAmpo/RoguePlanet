using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D),typeof(Collider2D))]
public class CelestialBodyBehavior : MonoBehaviour
{
    public static List<CelestialBodyBehavior> celestialBodyBehaviors;
    public Rigidbody2D rb;

    UniverseData uniData;
    //private UnityEngine.Vector3 force;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        uniData = UniverseData.Instance;
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

        float forceMagnitude = uniData.gravitationalConstant * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance,uniData.distanceExponent);
        UnityEngine.Vector3 force = direction.normalized * forceMagnitude;
        rbToAttract.AddForce(force);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(this.rb.mass < other.rigidbody.mass)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void Behavior()
    {
        return;
    }

    // private void OnDrawGizmosSelected() {

    //     foreach(CelestialBodyBehavior cbb in celestialBodyBehaviors)
    //     {
    //         Color c = Color.white;
    //         if(cbb != this)
    //         {
    //             c.a *= force.x;
    //         }
    //         Gizmos.DrawWireSphere(this.transform.position, cbb.transform.position.x-this.transform.position.x);
    //     }
    // }
}
