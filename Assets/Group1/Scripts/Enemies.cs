using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemies : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _checkDistance;
    private List<Transform> _enemies;
    public int Count => _enemies.Count;

    private void Start()
    {
        _enemies = new List<Transform>();
        foreach (EnemyMovement enemy in gameObject.GetComponentsInChildren<EnemyMovement>())
        {
            _enemies.Add(enemy.gameObject.transform);
        }
    }

    private void Update()
    {
        for (var i = 0; i < _enemies.Count; i++)
        {
            if (Vector3.Distance(_player.position, _enemies[i].position) < _checkDistance)
            {
                var temp = _enemies[i].gameObject;
                _enemies.RemoveAt(i);
                Destroy(temp);
            }
        }
    }
}
