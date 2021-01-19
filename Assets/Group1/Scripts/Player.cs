using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedChangeTimer;
    [SerializeField] private float _timerModifier;

    private void Start()
    {
        if (_speedChangeTimer > 0)
            StartCoroutine(ChangeSpeed(_timerModifier, _speedChangeTimer));
    }

    private void Update()
    {
        Vector3 direction = new Vector3();
        if (Input.GetKey(KeyCode.W))
            direction += Vector3.up;
        if (Input.GetKey(KeyCode.S))
            direction += Vector3.down;
        if (Input.GetKey(KeyCode.A))
            direction += Vector3.left;
        if (Input.GetKey(KeyCode.D))
            direction += Vector3.right;
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    private IEnumerator ChangeSpeed (float modifier, float delay)
    {
        float timer = delay;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        _speed *= modifier;      
    }
}
