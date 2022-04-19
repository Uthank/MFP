using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DropWrapper : MonoBehaviour
{
    [SerializeField] public GameObject _drop;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player) == true)
        {
            other.GetComponent<Inventory>().Add(_drop);
            Destroy(gameObject);
        }
    }
}
