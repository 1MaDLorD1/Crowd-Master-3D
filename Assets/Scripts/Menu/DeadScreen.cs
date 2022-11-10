using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadScreen : MonoBehaviour
{
    [SerializeField] private GameObject _loseMenuUI;
    [SerializeField] private Player _player;

    private HealthContainer _health;

    private OutOfAreaState _outOfAreaState;

    private void Awake()
    {
        _health = _player.GetComponent<HealthContainer>();
        _outOfAreaState = _player.GetComponent<OutOfAreaState>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }

    private void OnEnable()
    {
        _health.Died += OnDied;
        _outOfAreaState.Died += OnDied;
    }

    private void OnDisable()
    {
        _health.Died -= OnDied;
        _outOfAreaState.Died -= OnDied;
    }

    private void OnDied()
    {
        Pause();
    }

    public void StartGame()
    {
        Time.timeScale = 1.0F;
        SceneManager.LoadScene("SampleScene");
    }

    public void Pause()
    {
        Time.timeScale = 0.5F;
        _loseMenuUI.SetActive(true);
    }
}
