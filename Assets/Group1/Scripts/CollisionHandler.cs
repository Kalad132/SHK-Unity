using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _radius;

    private List<Transform> _colliders;

    public event UnityAction<GameObject> Collided;

    private void Start()
    {
        _colliders = new List<Transform>();
        foreach (CustomCollider item in GetComponentsInChildren<CustomCollider>())
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
                Collided?.Invoke(_colliders[i].gameObject);
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