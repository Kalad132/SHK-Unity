using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _boostSpeedModifier;
    [SerializeField] private float _boostBaseTime;

    private float _boostTimeLeft;

    public void BoostSpeed()
    {
        StartCoroutine(ChangeSpeed(_boostSpeedModifier, _boostBaseTime));
    }

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
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    private IEnumerator ChangeSpeed(float modifier, float time)
    {
        _speed *= _boostSpeedModifier;
        yield return new WaitForSeconds(_boostBaseTime);
        _speed /= _boostSpeedModifier;
    } 

}
