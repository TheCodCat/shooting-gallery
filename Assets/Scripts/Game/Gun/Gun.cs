using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    [SerializeField] protected Transform _firePoint;
    [SerializeField] protected int _damage;
    [SerializeField] protected float _fireDistance;
    [SerializeField] protected float _timeSpan;
    [SerializeField] protected bool _isFire;

    public abstract void Fire();
    public abstract void Reload();

    public async virtual UniTask IsFire()
    {
        _isFire = false;

        await UniTask.Delay(TimeSpan.FromSeconds(_timeSpan));

        _isFire = true;
    }
}
