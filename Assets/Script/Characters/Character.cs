using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private ParticleSystem dirtFoots;

    private static Character _instance;
    public static Character Instance => _instance;

    public float velocity;
    public float defense;
    public float attack;

    private Animator _animator;
    private Transform _transform;

    public void Awake()
    {
        _transform = transform;
        _instance = this;
        _animator = GetComponent<Animator>();
    }
    
    public void WalkAnimations(float velY, float velX)
    {
        _animator.SetFloat("VelX", velY);
        _animator.SetFloat("VelY", velX);
      
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
