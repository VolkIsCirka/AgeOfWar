using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private UnitFinder _finder;

    private bool _isStay;

    private void OnEnable()
    {
        _finder.Found += OnFound;
        _finder.Lost += OnLost;
    }

    private void Start()
    {
        _isStay = _finder.Units.Count > 0;
    }

    private void Update()
    {
        if(_isStay == false)
        {
            int direction = transform.localScale.x > 0 ? 1 : -1;
            transform.position = new Vector3(transform.position.x + direction * _speed * Time.deltaTime,
                transform.position.y, transform.position.z);
        }
    }

    private void OnDisable()
    {
        _finder.Found -= OnFound;
        _finder.Lost -= OnLost;
    }
    public void Init(Team team)
    {
        switch (team)
        {
            case Team.Player:
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x),
                    transform.localScale.y, transform.localScale.z);
                break;
            case Team.PC:
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x),
                    transform.localScale.y, transform.localScale.z);
                break;
            default:
                throw new ArgumentException("Не может быть третьей комманды");
        }
    }

    private void OnFound(IReadOnlyList<Unit> units)
    {
        _isStay = true;
    }

    private void OnLost(Unit unit)
    {
        _isStay = _finder.Units.Count > 0;
    }
}
