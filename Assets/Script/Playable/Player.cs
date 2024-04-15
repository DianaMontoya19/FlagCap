using System;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public enum Team
{
    Blue,
    Red,
}

public class Player : MonoBehaviour
{
    private Team _team;
    public Team Team => _team;
    public float health = 100f;
    private Character _character;
    private CharacterIA _characterEnemy;
    private IMovable _movable;

    private Rigidbody _rb;
    public Rigidbody Rb => _rb;
    private Transform _transform;
    public Transform Transform => _transform;
    private NavMeshAgent _navMeshAgent;
    public NavMeshAgent NavMeshAgent => _navMeshAgent;

    private static Player _instance;
    public static Player Instance => _instance;

   
  



    protected void Awake()
    {
        _instance = this;
        _rb = GetComponent<Rigidbody>();
        _transform = transform;
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }


    public void Configure(Team team, Character character, IMovable movable)
    {
        _team = team;
        _character = Instantiate(character, _transform);
        _movable = movable;
    }

    public void ConfigureEnemy(Team team, CharacterIA characterEne, IMovable movable)
    {
        _team = team;
        _characterEnemy = Instantiate(characterEne, _transform);
        _movable = movable;
    }

    public void Update()
    {
        _movable.Update();
    }

    protected void FixedUpdate()
    {
        _movable.FixedUpdate();
    }

    private void OnCollisionEnter(Collision other)
    {
        _movable.OnCollisionEnter(other);
    }

    private void OnCollisionExit(Collision other)
    {
        _movable.OnCollisionExit(other);
    }

    private void OnTriggerEnter(Collider other)
    {
        _movable.OnTriggerEnter(other);
    }

    private void OnTriggerExit(Collider other)
    {
        _movable.OnTriggerExit(other);
    }
    public void Die()
    {

        gameObject.SetActive(false);
        Invoke("Reactive", 1f);
        Debug.Log("ESTOY MURIENDO");
       
    }
    public void Reactive()
    {
        gameObject.SetActive(true);
        transform.position = new Vector3(-0.0799999982f, -6.51999998f, -17.2800007f);
    }
    
}