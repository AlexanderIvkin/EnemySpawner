using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Man : MonoBehaviour
{
    [SerializeField] private Transform _waypointsParent;
    [SerializeField] private float _speed;

    private Vector3[] _waypointPositions;
    private int _currentPointIndex = 0;

    private void Start()
    {
        _waypointPositions = new Vector3[_waypointsParent.childCount];

        for (int i = 0; i < _waypointPositions.Length; i++)
        {
            _waypointPositions[i] = _waypointsParent.GetChild(i).position;
        }
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _waypointPositions[_currentPointIndex], _speed * Time.deltaTime);

        if (transform.position == _waypointPositions[_currentPointIndex])
        {
            ReturnNextIndex();
        }
    }

    private void ReturnNextIndex()
    {
        _currentPointIndex++;

        if (_currentPointIndex == _waypointPositions.Length)
        {
            _currentPointIndex = 0;
        }
    }
}
