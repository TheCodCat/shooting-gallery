using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string _nameScene;
    public async void GameLoading(string scenname)
    {
        await SceneManager.LoadSceneAsync(scenname).ToUniTask();
    }
}
