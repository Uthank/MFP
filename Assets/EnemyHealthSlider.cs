using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class EnemyHealthSlider : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private Coroutine smoothChangeValue;
    private float speed = 1f;
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _enemy.HealthChanged += OnValueChanged;
        _enemy.Dying += DisableOnDie;
    }

    private void OnDisable()
    {
        _enemy.HealthChanged -= OnValueChanged;
        _enemy.Dying -= DisableOnDie;
    }

    private void LateUpdate()
    {
        transform.LookAt(Camera.main.transform);
    }

    private void OnValueChanged(float targetValue)
    {
        if (smoothChangeValue != null)
            StopCoroutine(smoothChangeValue);

        smoothChangeValue = StartCoroutine(SmoothChangeValue(targetValue));

    }

    private IEnumerator SmoothChangeValue(float targetValue)
    {
        while (Mathf.Abs(_slider.value - targetValue) > 0.01f)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, speed * Time.deltaTime);
            yield return null;
        }

        _slider.value = targetValue;
    }

    private void DisableOnDie()
    {
        gameObject.SetActive(false);
    }
}
