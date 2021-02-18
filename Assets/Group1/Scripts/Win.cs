using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] private GameObject _gameoverScreen;
    [SerializeField] private GameObject _player;
    [SerializeField] private EnemyCollision _enemies;

    private void Update()
    {
        if (_enemies.Count == 0)
            GameOver();
    }

    private void GameOver()
    {
        _gameoverScreen.SetActive(true);
        _player.SetActive(false);
    }
}
