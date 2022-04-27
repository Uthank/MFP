using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] private List<Vector3> _positions = new List<Vector3>();

    private int _indexOfCurrentPosition = 0;

    public bool HasPath { get; private set; } = false;

    private void Awake()
    {
        foreach (var point in GetComponentsInChildren<PathPoint>())
        {
            _positions.Add(point.gameObject.transform.position);
            point.transform.parent = null;
        }

        if (_positions.Count > 1)
            HasPath = true;
    }

    public Vector3 GetNextPosition()
    {
        _indexOfCurrentPosition++;

        if (_indexOfCurrentPosition == _positions.Count)
            _indexOfCurrentPosition = 0;

        return _positions[_indexOfCurrentPosition];
    }
}
