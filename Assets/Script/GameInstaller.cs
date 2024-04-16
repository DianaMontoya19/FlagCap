using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class GameInstaller : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private Player enemy;
        [SerializeField] private Character characterPlayer;
        [SerializeField] private CharacterIA characterEnemy;

        [SerializeField] private EnemyStateEnum[] enums;
        [SerializeField] private Transform[] transforms;

        [SerializeField] private Transform position;

        private Dictionary<EnemyStateEnum, Transform> _positions = new();

        private void Awake()
        {
            for (int i = 0; i < enums.Length; i++)
            {
                _positions.Add(enums[i], transforms[i]);
            }
        }

        private void Start()
        {
            IMovable movable = new PlayerInput(600f, player.Rb, player.Transform, 5f);
            IMovable movalbeEnemy = new AiInput(Team.Red, _positions, enemy.NavMeshAgent);
            player.Configure(Team.Blue, characterPlayer, movable);
            enemy.ConfigureEnemy(Team.Red, characterEnemy, movalbeEnemy);
        }
    }
}