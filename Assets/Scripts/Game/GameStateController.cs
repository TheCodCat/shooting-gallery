using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour
{
    public static event UnityAction<GameState> OnGameStateChanged;
    [SerializeField] private GameState _currentGameState;
    [SerializeField] private ArchoryController _archoryController;
    [Header("Рестарт")]
    [SerializeField] private Button _restartButton;
    [SerializeField] private string _gameNameScene;

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
    public async void Restart()
    {
        await SceneManager.LoadSceneAsync(_gameNameScene);
    }
}
