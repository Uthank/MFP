using UnityEngine;

[RequireComponent(typeof(Player))]
public class Interactor : MonoBehaviour
{
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<RespawnPoint>(out RespawnPoint respawnPoint) == true)
        {
            _player.SetRespawnPoint(respawnPoint.transform.position);
        }
    }
}
