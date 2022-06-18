using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnitHealth))]
[RequireComponent(typeof(UnitMover))]
[RequireComponent(typeof(UnitAttacker))]
public class Unit : MonoBehaviour
{
    private UnitHealth _health;
    private UnitMover _mover;
    private UnitAttacker _attacker;
    private Team _team;

    public event Action<Unit> Died;

    public Team MyTeam => _team;

    public bool IsLive => _health.Health > 0;

    public float DistanceForAttack => _attacker.DistanceForAttack;

    public bool HaveEnemy => _attacker.IsFree == false;

    private void Awake()
    {
        _health = GetComponent<UnitHealth>();
        _mover = GetComponent<UnitMover>();
        _attacker = GetComponent<UnitAttacker>();
    }

    private void OnEnable()
    {
        _health.Died += OnDied;
    }

    private void Start()
    {
        _mover.Init(MyTeam);
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

    public void Move() => _mover.Move();

    public void TakeEnemy(Unit unit) => _attacker.TakeEnemy(unit);

    private void OnDied()
    {
        Died?.Invoke(this);
        Destroy(gameObject);
    }
}
