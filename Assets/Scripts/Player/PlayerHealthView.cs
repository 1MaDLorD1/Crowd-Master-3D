using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealthView : MonoBehaviour
{
    [SerializeField] private TMP_Text _health;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.HealthUpdated += OnHealthUpdated;
    }

    private void OnDisable()
    {
        _player.HealthUpdated -= OnHealthUpdated;
    }

    private void OnHealthUpdated(int health)
    {
        _health.text = $"Health: {health}";
    }
}
