using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitsAll : MonoBehaviour
{
    [SerializeField] private float _distanceForMove;

    private Dictionary<Team, List<Unit>> _units;

    private void Awake()
    {
        _units = new Dictionary<Team, List<Unit>>
        {
            { Team.Player, new List<Unit>() },
            { Team.PC, new List<Unit>() },
        };
    }

    private void Update()
    {
        foreach(Team team in _units.Keys)
        {
            if(_units[team].Count>0)
            {
                if (_units[GetOppositeTeam(team)].Count <= 0 ||
                    Mathf.Abs(_units[GetOppositeTeam(team)][0].transform.position.x - _units[team][0].transform.position.x) >= _distanceForMove)
                {
                    _units[team][0].Move();
                }

                for (int i = 1; i < _units[team].Count; i++)
                {
                    if (Mathf.Abs(_units[team][i].transform.position.x - _units[team][i - 1].transform.position.x) >= _distanceForMove &&
                        (_units[GetOppositeTeam(team)].Count <= 0 ||
                        Mathf.Abs(_units[GetOppositeTeam(team)][0].transform.position.x - _units[team][i].transform.position.x) >= _distanceForMove))
                    {
                        _units[team][i].Move();
                    }
                }
            }
            if(_units[GetOppositeTeam(team)].Count > 0)
            {
                for (int i = 0; i < _units[team].Count; i++)
                {
                    if (_units[team][i].HaveEnemy == false &&
                        Mathf.Abs(_units[team][i].transform.position.x - _units[GetOppositeTeam(team)][0].transform.position.x) 
                        <= _units[team][i].DistanceForAttack)
                    {
                        _units[team][i].TakeEnemy(_units[GetOppositeTeam(team)][0]);
                    }
                }
            }
        }
    }

    public void TakeUnit(Unit unit)
    {
        _units[unit.MyTeam].Add(unit);
        unit.Died += OnDied;
    }

    private void OnDied(Unit unit)
    {
        _units[unit.MyTeam].Remove(unit);
        unit.Died -= OnDied;
    }

    private Team GetOppositeTeam(Team team)
    {
        switch (team)
        {
            case Team.Player:
                return Team.PC;
            case Team.PC:
                return Team.Player;
            default:
                throw new ArgumentOutOfRangeException(nameof(team), "Неизвестная тима");
        }
    }
}
