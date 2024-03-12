using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FinishZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            LoadFinish();
        }
    }

    private void LoadFinish()
    {
        Debug.Log("Congrats you finished!");
    }
}
