using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _radius;

    private List<Transform> _colliders;

    public event UnityAction EnemyKilled;

    private void Start()
    {
        _colliders = new List<Transform>();
        foreach (Collider item in GetComponentsInChildren<Collider>())
        {
            _colliders.Add(item.gameObject.transform);
        }
    }

    private void Update()
    {
        for (var i = 0; i < _colliders.Count; i++)
        {
            if (Vector3.Distance(_player.transform.position, _colliders[i].position) < _radius)
            {
                if ( _colliders[i].TryGetComponent(out EnemyMovement enemy))
                {
                    EnemyKilled?.Invoke();
                }
                if (_colliders[i].TryGetComponent(out Booster booster))
                {
                    _player.BoostSpeed(booster.Modificatitor, booster.Time);
                }
                DestroyAt(i);
            }
        }
    }

    private void DestroyAt(int index)
    {
        var collider = _colliders[index].gameObject;
        _colliders.RemoveAt(index);
        Destroy(collider);
    }
}