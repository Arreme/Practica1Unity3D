using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_GameManager : MonoBehaviour
{
    public static S_GameManager _gameManager = null;

    [SerializeField] private Transform[] _checkPoints;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _ui;

    private bool _move;

    void Awake()
    {
        if (_gameManager == null)
        {
            _gameManager = this;
            _move = true;
        } else
        {
            Destroy(gameObject);
        }
    }

    public void DeathEvent()
    {
        _ui.SetActive(true);
        _player.GetComponent<PlayerHealthSysem>().enabled = false;
        _player.GetComponent<FPSController>().enabled = false;
        _player.GetComponent<CharacterController>().enabled = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        _move = true;
        
    }

    private void LateUpdate()
    {
        if (_move)
        {
            _player.transform.position = _checkPoints[StData.CurrentCheckpoint].position;
            _player.transform.rotation = _checkPoints[StData.CurrentCheckpoint].rotation;
            _move = false;
        }
    }
}
