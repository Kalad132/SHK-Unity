using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedChangeTimer;
    [SerializeField] private float _timerModifier;

    private void Update()
    {
        Vector3 direction = new Vector3();
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    private IEnumerator BoostSpeed (float modifier, float time)
    {
        _speed *= modifier;
        new WaitForSeconds(time);
        _speed /= modifier;
        return null;
    }
}
