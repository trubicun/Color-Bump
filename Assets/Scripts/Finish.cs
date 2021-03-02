using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Finish : MonoBehaviour
{
    [SerializeField] private float _finishTime = 2f;
    [SerializeField] private GameObject _player;

    public delegate void EventHandler();
    public event EventHandler OnFinished;

    private ParticleSystem[] _particles;
    private bool _finished = false;

    private void Start()
    {
        _particles = GetComponentsInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player && !_finished)
        {
            OnFinished?.Invoke();
            _finished = true;
            PlayParticles();
        }
    }

    private void PlayParticles()
    {
        foreach(ParticleSystem particle in _particles)
        {
            particle.Play();
        }
    }
}
