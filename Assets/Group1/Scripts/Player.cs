using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float _baseSpeed;
    [SerializeField] private float _boostSpeedModifier;
    [SerializeField] private float _boostBaseTime;

    private float _boostTimeLeft;

    private float _currentSpeed => _boostTimeLeft <= 0 ? _baseSpeed : _baseSpeed * _boostSpeedModifier;

    private void Start()
    {
        _boostTimeLeft = 0;
    }

    private void Update()
    {
        if (_boostTimeLeft > 0)
            _boostTimeLeft -= Time.deltaTime;
        Vector3 direction = new Vector3();
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
        transform.Translate(direction * _currentSpeed * Time.deltaTime);
    }

    public void BoostSpeed()
    {
        _boostTimeLeft = _boostBaseTime;
    }
}
