using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthSlider : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Coroutine smoothChangeValue;
    private float speed = 0.5f;
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnValueChanged;
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
}   
