using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _moveRange;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = Random.insideUnitCircle * _moveRange;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
        if (transform.position == _targetPosition)
            _targetPosition = GetNewPosition(_moveRange);
    }

    private Vector3 GetNewPosition (float range)
    {
        return Random.insideUnitCircle * range;
    }
}
