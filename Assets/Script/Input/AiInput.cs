using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

[Serializable]
public enum EnemyStateEnum
{
    Player,
    Flag,
    Position,
   
}

public class AiInput : IMovable
{
    private readonly Team _team;
    private readonly Dictionary<EnemyStateEnum, Transform> _positions;
    private readonly NavMeshAgent _agent;
    //private readonly Transform _transform;
    private EnemyStateEnum _currentState;
    private GameObject _ia;
    
    private bool _isActive = false;


    private EnemyStateEnum IsFlagCaptured =>
        FlagManager.Instance.currentState == FlagStatesEnum.Captured && _isActive
            ? EnemyStateEnum.Position
            : EnemyStateEnum.Flag;

   

    public AiInput(Team team, Dictionary<EnemyStateEnum, Transform> positions, NavMeshAgent agent, EnemyStateEnum currentState = EnemyStateEnum.Flag)
    {
        _team = team;
        _positions = positions;
        _agent = agent;
        _currentState = currentState;
    }

    public void OnCollisionEnter(Collision collision)
    {
    
        if (collision.gameObject.TryGetComponent(out FlagObject flag))
        {
  
                _isActive = true;
                FlagManager.Instance.CaptureFlag(CharacterIA.Instance.transform,false); // Captura la bandera
                _currentState = IsFlagCaptured; // Cambia el estado del AI

        }
        if (collision.gameObject.TryGetComponent(out Player player))
        {

            player.Die();

            if (!player.gameObject.activeSelf)
            {

                _currentState = IsFlagCaptured;
               

                if (FlagManager.Instance.capturedBy)
                {
                    FlagManager.Instance.Spawn();

                }

            }

        }



 
    }

    public void OnCollisionExit(Collision collision) {}

    public void OnTriggerEnter(Collider other)
    {
        
        if (!other.gameObject.TryGetComponent(out Player player)) return;
        //if (player.Team == _team) return;
        
        _positions[EnemyStateEnum.Player] = player.transform;
        _currentState = EnemyStateEnum.Player;
    }
    
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            _currentState = IsFlagCaptured;
            Debug.Log("no estoy");
        }
    }
    
    private void Move(EnemyStateEnum state)
    {
        Transform destine = _positions[state];
        _agent.SetDestination(destine.position);
     
    }
    
    public void FixedUpdate()
    {
        Move(_currentState);
    }
    
    public void Update()
    {

        Stop();


    }    
    public void Stop()
    {
        if (!_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance)
        {
            //_agent.isStopped = true;
            FlagManager.Instance.Point();
            
            Debug.Log("Gane"+_currentState);
        }
    }
}