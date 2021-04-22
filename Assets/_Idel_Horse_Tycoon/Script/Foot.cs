using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot : MonoBehaviour
{
    public ParticleSystem ParticleSystem;

    private void Awake()
    {
        ParticleSystem = transform.GetChild(0).GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        ParticleSystem.Play();
    }
}
