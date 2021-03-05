﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _range;

    private Vector3 _target;

    private void Start()
    {
        _target = transform.position;
    }

    private void Update()
    {
        Move();
        if (transform.position == _target)
            _target = GetNewTarget(_range);
    }

    private Vector3 GetNewTarget (float range)
    {
        return Random.insideUnitCircle * range;
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
    }
}
