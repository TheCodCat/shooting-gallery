using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archery : MonoBehaviour, IDamageble
{
    [SerializeField] private bool _isLive = true;
    public void damage(int damage)
    {
        if (!_isLive) return; 

        Debug.Log("Меня убили");
        _isLive = false;
        ArchoryController.Instance.ChangeLiveCount();
    }
    public bool GetLive()
    {
        return _isLive;
    }
}
