using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFollow : MonoBehaviour
{
    [SerializeField] ParticleSystem leadParticles;
    [SerializeField] GameObject[] particlePrefabs;
    [SerializeField] float rotationSpeed = 25;

    List<Transform> particleTransforms = new List<Transform>();
    ParticleSystem.Particle[] activeParticles;

    bool particlesSpawned;

    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        activeParticles = new ParticleSystem.Particle[leadParticles.main.maxParticles];

        yield return new WaitUntil(ParticleSystemReady);
        Debug.Log("Particles Ready");
        int particlesAlive = leadParticles.GetParticles(activeParticles);
        for (int i = 0; i < particlesAlive; i++)
        {
            Transform particle = Instantiate(particlePrefabs[Random.Range(0,particlePrefabs.Length)], activeParticles[i].position, Quaternion.Euler(activeParticles[i].rotation3D), this.transform).transform;
            particleTransforms.Add(particle);
        }

        particlesSpawned = true;
    }

    void Update()
    {
        if(!particlesSpawned) return;

        int particlesAlive = leadParticles.GetParticles(activeParticles);
        for (int i = 0; i < particlesAlive; i++)
        {
            particleTransforms[i].position = activeParticles[i].position;
            particleTransforms[i].rotation = Quaternion.RotateTowards(particleTransforms[i].rotation, Quaternion.LookRotation(activeParticles[i].totalVelocity), rotationSpeed * Time.deltaTime);
            particleTransforms[i].localScale = new Vector3(activeParticles[i].size, activeParticles[i].size, activeParticles[i].size);
        }
    }

    bool ParticleSystemReady()
    {

        Debug.Log("PC: " + leadParticles.particleCount);
        Debug.Log("MPC: " + leadParticles.main.maxParticles);
        if (leadParticles.particleCount == leadParticles.main.maxParticles)
            return true;
        else
            return false;
    }
}