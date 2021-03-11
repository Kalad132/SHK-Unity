using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] private GameObject _gameoverScreen;
    [SerializeField] private GameObject _player;
    [SerializeField] private CollisionHandler _collisionHandler;

    private int _enemiesCount;

    private void Start()
    {
        _enemiesCount = GetComponentsInChildren<EnemyMovement>().Length;
    }

    private void OnEnable()
    {
        _collisionHandler.Collided += OnCollision;
    }

    private void OnDisable()
    {
        _collisionHandler.Collided -= OnCollision;
    }

    private void GameOver()
    {
        _gameoverScreen.SetActive(true);
        _player.SetActive(false);
    }

    private void OnCollision(GameObject collision)
    {
        if (collision.TryGetComponent(out EnemyMovement enemy))
        {
        _enemiesCount--;
        if (_enemiesCount == 0)
            GameOver();
        }
    }
}
