using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public static event UnityAction<float> OnChangeTimeValue;
    [SerializeField] private float _time;
    [SerializeField] bool _isPlaying = false;        

    private void OnEnable()
    {
        GameStateController.OnGameStateChanged += ChandeTimer;
    }
    public float Time
    {
        get
        {
            return _time;
        }
        set
        {
            _time = value;
            OnChangeTimeValue?.Invoke(value);
        }
    }

    public void ChandeTimer(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Pause:
                _isPlaying = false;
                break;

            case GameState.Game:
                _isPlaying = true;
                EnableTimer();
                break;
        }
    }
    public async void EnableTimer()
    {
        if(_isPlaying) return;

        while (_isPlaying)
        {
            Time += UnityEngine.Time.deltaTime;
            await UniTask.Delay(0);
        }
    }
}
