using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterIA : MonoBehaviour
{
    [SerializeField] private ParticleSystem dirtFoots;

    private Animator _animator;
    private static CharacterIA _instance;
    public static CharacterIA Instance => _instance;

    private Transform _transform;
    public void Awake()
    {
        _transform = transform;
        _instance = this;
        _animator = GetComponent<Animator>();
    }

    public void ActivateFoots(bool state)
    {
        if (state)
        {
            dirtFoots.Play();
        }
        else
        {
            dirtFoots.Stop();
        }
    }
}
