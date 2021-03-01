using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _collisionRadius;

    private List<Transform> _colliders;

    public int EnemiesCount { get; private set; }

    private void Start()
    {
        _colliders = new List<Transform>();
        foreach (Booster item in GetComponentsInChildren<Booster>())
        {
            _colliders.Add(item.gameObject.transform);
        }
        foreach (EnemyMovement item in GetComponentsInChildren<EnemyMovement>())
        {
            _colliders.Add(item.gameObject.transform);
            EnemiesCount++;
        }
    }

    private void Update()
    {
        for (var i = 0; i < _colliders.Count; i++)
        {
            if (Vector3.Distance(_player.transform.position, _colliders[i].position) < _collisionRadius)
            {
                var collider = _colliders[i].gameObject;
                if (collider.TryGetComponent(out Booster booster))
                    _player.BoostSpeed();
                else if (collider.TryGetComponent(out EnemyMovement enemy))
                    EnemiesCount--;
                _colliders.RemoveAt(i);
                Destroy(collider);
            }
        }
    }
}