using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnitHealth))]
[RequireComponent(typeof(UnitMover))]

public class Unit : MonoBehaviour
{
    private UnitHealth _health;
    private UnitMover _mover;
    private Team _team;

    public event Action<Unit> Died;

    public Team Team => _team;

    private void Awake()
    {
        _health = GetComponent<UnitHealth>();
        _mover = GetComponent<UnitMover>();
    }

    private void OnEnable()
    {
        _health.Died += OnDied;
    }

    private void Start()
    {
        _mover.Init(Team);
    }

    private void OnDisable()
    {
        _health.Died -= OnDied;
    }

    public void Init(Team team)
    {
        _team = team;
    }

    public void TakeDamage(int damage) => _health.TakeDamage(damage);

    private void OnDied()
    {
        Died?.Invoke(this);
        Destroy(gameObject);
    }
}
