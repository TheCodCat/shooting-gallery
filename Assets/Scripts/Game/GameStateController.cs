using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class GameStateController : MonoBehaviour
{ 
    public static event UnityAction<GameState> OnGameStateChanged;
    [SerializeField] private GameState _currentGameState;

    public void ChangeState(GameState gameState)
    {
        _currentGameState = gameState;
        OnGameStateChanged?.Invoke(gameState);
    }
    public void StartButton()
    {
        OnGameStateChanged?.Invoke(GameState.Game);
    }
    public void StopButton()
    {
        OnGameStateChanged?.Invoke(GameState.Pause);
    }
}
