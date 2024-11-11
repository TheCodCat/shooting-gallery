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

    public virtual void Fire()
    {
        if (!_isFire) return;

        Ray ray = new Ray(_firePoint.position, _firePoint.forward);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, _fireDistance))
        {
            Debug.DrawRay(ray.origin, ray.direction * hitInfo.distance, Color.red);
            if (hitInfo.collider.transform.parent.TryGetComponent(out IDamageble component))
            {
                component.damage(_damage);
            }
        }
        IsFire().AsAsyncUnitUniTask();
    }
    public abstract void Reload();

    public async virtual UniTask IsFire()
    {
        _isFire = false;

        await UniTask.Delay(TimeSpan.FromSeconds(_timeSpan));

        _isFire = true;
    }
}
