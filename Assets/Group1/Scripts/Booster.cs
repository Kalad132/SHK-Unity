using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    [SerializeField] float _modificator;
    [SerializeField] float _time;

    public float Modificatitor => _modificator;
    public float Time => _time;
}
