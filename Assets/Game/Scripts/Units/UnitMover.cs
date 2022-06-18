using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    public event Action Died;

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

    public void Die()
    {
        Died?.Invoke();
    }

    public void Move()
    {
        int direction = transform.localScale.x > 0 ? 1 : -1;
        transform.position = new Vector3(transform.position.x + direction * _speed * Time.deltaTime,
            transform.position.y, transform.position.z);
    }
}
