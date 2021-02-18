using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyCollision : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _collisionRadius;

    private List<Transform> _enemies;

    public int Count => _enemies.Count;

    private void Start()
    {
        _enemies = new List<Transform>();
        foreach (EnemyMovement item in gameObject.GetComponentsInChildren<EnemyMovement>())
        {
            _enemies.Add(item.gameObject.transform);
        }
    }

    private void Update()
    {
        for (var i = 0; i < _enemies.Count; i++)
        {
            if (Vector3.Distance(_player.position, _enemies[i].position) < _collisionRadius)
            {
                var temp = _enemies[i].gameObject;
                _enemies.RemoveAt(i);
                Destroy(temp);
            }
        }
    }
}
