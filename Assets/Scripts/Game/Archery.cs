using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archery : MonoBehaviour, IDamageble
{
    [SerializeField] private bool _isLive = true;
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private Color _colorDead;
    [SerializeField] private AudioClip _clip;
    [SerializeField, Range(0,1)] private float _volume;
    public void damage()
    {
        if (!_isLive) return; 

        Debug.Log("Меня убили");
        _isLive = false;
        _renderer.material.color = _colorDead;
        ArchoryController.Instance.ChangeLiveCount();
        AudioSource.PlayClipAtPoint(_clip,transform.position, _volume);
    }
    public bool GetLive()
    {
        return _isLive;
    }
}
