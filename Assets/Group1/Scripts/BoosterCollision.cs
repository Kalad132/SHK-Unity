using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BoosterCollision : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _collisionRadius;

    private List<Transform> _boosters;

    private void Start()
    {
        _boosters = new List<Transform>();
        foreach (Booster item in gameObject.GetComponentsInChildren<Booster>())
        {
            _boosters.Add(item.gameObject.transform);
        }
    }

    private void Update()
    {
        for (var i = 0; i < _boosters.Count; i++)
        {
            if (Vector3.Distance(_player.transform.position, _boosters[i].position) < _collisionRadius)
            {
                var temp = _boosters[i].gameObject;
                _boosters.RemoveAt(i);
                Destroy(temp);
                _player.BoostSpeed();
            }
        }
    }
}