using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Quaternion _rotation;

    private void Update()
    {
        transform.position = _player.transform.position + _offset;
        transform.rotation = _rotation;
    }
}
