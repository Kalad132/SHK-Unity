using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private CollisionHandler _collisionHandler;

    public void BoostSpeed(float modifier, float time)
    {
        StartCoroutine(ChangeSpeed(modifier, time));
    }

    private void OnEnable()
    {
        _collisionHandler.Collided += OnCollision;
    }

    private void OnDisable()
    {
        _collisionHandler.Collided -= OnCollision;
    }

    private void OnCollision(GameObject collider)
    {
        if (collider.TryGetComponent(out Booster booster))
        {
            BoostSpeed(booster.Modificatitor, booster.Time);
        }
    }

    private void Update()
    {
        Vector3 direction = new Vector3();
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    private IEnumerator ChangeSpeed(float modifier, float time)
    {
        _speed *= modifier;
        yield return new WaitForSeconds(time);
        _speed /= modifier;
    } 
}
