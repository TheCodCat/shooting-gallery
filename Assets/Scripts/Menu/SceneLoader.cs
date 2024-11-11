using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string _nameScene;
    public async void GameLoading()
    {
        await SceneManager.LoadSceneAsync(_nameScene).ToUniTask();
    }
}
