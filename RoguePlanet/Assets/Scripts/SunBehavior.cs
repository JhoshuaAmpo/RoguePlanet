using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunBehavior : CelestialBodyBehavior
{
    [SerializeField] float XScalar;

    private void FixedUpdate() {
        base.AttractLoop();
        Behavior();
    }

    protected override void Behavior()
    {
        base.rb.AddForce(XScalar * transform.right,ForceMode2D.Force);
    }

}
