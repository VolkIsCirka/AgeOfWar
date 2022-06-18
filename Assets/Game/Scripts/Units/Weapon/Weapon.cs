using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private float _cooldown;
    [SerializeField] private int _damage;
    [SerializeField] private int _distanceForAttack;

    private float _timeBeforeAttack;
    private Unit _target;

    public event Action LostTarget;

    public bool IsFree => _target == null;

    public int Damage => _damage;

    public int DistanceForAttack => _distanceForAttack;

    private void Awake()
    {
        _target = null;
    }

    private void Update()
    {
        if(IsFree == false)
        {
            _timeBeforeAttack = Mathf.Max(_timeBeforeAttack - Time.deltaTime, 0);

            if(_timeBeforeAttack == 0)
            {
                Attack(_target);

                if (_target.IsLive == false)
                {
                    LostTarget?.Invoke();
                }
                _timeBeforeAttack = _cooldown;
            }
        }
    }

    public void NewTarget(Unit unit)
    {
        _target = unit;
        _timeBeforeAttack = _cooldown;
    }

    protected abstract void Attack(Unit unit);
}
