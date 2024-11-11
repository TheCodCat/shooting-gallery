using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameStateController : MonoBehaviour
{ 
    public static event UnityAction<GameState> OnGameStateChanged;
    [SerializeField] private GameState _currentGameState;
    [SerializeField] private ArchoryController _archoryController;
    [SerializeField] private Button _restartButton;

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
        if(_archoryController.currentLive != _archoryController.GetLiveCount()) return;

        OnGameStateChanged?.Invoke(GameState.Pause);
        _restartButton.interactable = true;
    }
}
