using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _range;

    private Vector3 _position;

    private void Start()
    {
        GetNewPosition(_range);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _position, _speed * Time.deltaTime);
        if (transform.position == _position)
            _position = GetNewPosition(_range);
    }

    private Vector3 GetNewPosition (float range)
    {
        return Random.insideUnitCircle * range;
    }
}
