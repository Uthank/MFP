using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player) == true)
        {
            player.RespawnPoint = transform.position;
        }
    }
}
