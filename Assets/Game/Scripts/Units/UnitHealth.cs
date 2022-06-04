using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _health;

    public int Health => _health;
    public int MaxHealth => _maxHealth;

    public event Action<int> SettedHealth;
    public event Action Died;

    private void Awake()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        SetHealth(Health - damage);
    }

    public void Heal(int addedHealth)
    {
        SetHealth(Health + addedHealth);
    }

    private void SetHealth(int newHealth)
    {
        _health = Mathf.Clamp(newHealth, 0, _maxHealth);
        SettedHealth?.Invoke(Health);

        if(Health == 0)
        {
            Died?.Invoke();
        }
    }
}
