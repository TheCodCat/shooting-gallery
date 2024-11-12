using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ArchoryController : MonoBehaviour
{
    public static ArchoryController Instance;
    public static event UnityAction<int> OnChageArchoryLive;
    [SerializeField] private List<Archery> _archeries;
    [SerializeField] private int _currentLive;
    public int currentLive
    {
        get
        {
            return _currentLive;
        }
        set
        {
            _currentLive = value;
            OnChageArchoryLive?.Invoke(value);
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    public void ChangeLiveCount()
    {
        currentLive = _archeries.Where(a => !a.GetLive()).Count();
    }

    public int GetLiveCount() => _archeries.Count();
}
