using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    [SerializeField] protected Transform _firePoint;
    [SerializeField] protected float _fireDistance;
    [SerializeField] protected float _timeSpan;
    [SerializeField] protected bool _isFire;
    [Header("��������")]
    [SerializeField] protected ParticleSystem _particleSystem;
    [SerializeField] protected AudioSource _audioSource;
    public virtual void Fire()
    {
        if (!_isFire) return;

        _particleSystem.Play();

        _audioSource.pitch = UnityEngine.Random.Range(0.95f,1f);
        _audioSource.Play();

        Ray ray = new Ray(_firePoint.position, _firePoint.forward);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, _fireDistance))
        {
            if (hitInfo.collider.TryGetComponent(out IDamageble component))
            {
                component.damage();
            }
        }
        IsFire().AsAsyncUnitUniTask();
        Debug.DrawRay(ray.origin, ray.direction * hitInfo.distance, Color.red);
    }
    public virtual void Reload()
    {

    }

    public async virtual UniTask IsFire()
    {
        _isFire = false;

        await UniTask.Delay(TimeSpan.FromSeconds(_timeSpan));

        _isFire = true;
    }
}
