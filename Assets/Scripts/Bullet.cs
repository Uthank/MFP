using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _particleOnDestroy;
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    public Transform Target;
    public float Damage;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rigidbody.velocity = (Target.position + Vector3.up * 1.5f - transform.position).normalized * _speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemy) == false)
        {
            if (other.gameObject.TryGetComponent<Player>(out Player player))
            {
                player.TakeDamage(Damage);
            }

            gameObject.SetActive(false);
            ParticleSystem particle = Instantiate(_particleOnDestroy, transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
            Destroy(particle.gameObject, particle.main.duration);
            Destroy(gameObject, particle.main.duration);
        }
    }
}
