using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Arrow : MonoBehaviour
{
    [SerializeField] private float _speed = 15f;
    [SerializeField] private float _lifeTime = 2f;

    private float _lifeTimeCurrent;
    private Rigidbody _rigidbody;
    private Collider _collider;
    private Vector3 _velocity;
    public float Damage;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
        _velocity = transform.rotation * Vector3.right * _speed;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _velocity;
        _lifeTimeCurrent += Time.fixedDeltaTime;

        if (_lifeTimeCurrent >= _lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(Damage);
        }

        if (other.gameObject.TryGetComponent(out RespawnPoint respawnPoint))
        {
            return;
        }

        _lifeTimeCurrent -= 10f;
        _rigidbody.isKinematic = true;
        _collider.enabled = false;
        transform.SetParent(other.transform);
    }
}
