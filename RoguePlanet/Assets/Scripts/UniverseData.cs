using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniverseData : MonoBehaviour
{
    public static UniverseData Instance { get; private set; }
    private void Awake() {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
    }

    public float gravitationalConstant = 1f;
    public float distanceExponent = 2f;
}
