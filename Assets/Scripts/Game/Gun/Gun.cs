using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMasks;
    [SerializeField] protected Transform _firePoint;
    [SerializeField] protected float _fireDistance;
    [SerializeField] protected float _timeSpan;
    [SerializeField] protected bool _isFire;
    [Header("Партиклы")]
    [SerializeField] protected ParticleSystem _particleSystem;
    [SerializeField] protected AudioSource _audioSource;
    [SerializeField] protected ParticleSystem _particleSystemFirePoint;
    public virtual void Fire()
    {
        if (!_isFire) return;

        _particleSystem.Play();

        _audioSource.pitch = UnityEngine.Random.Range(0.95f,1f);
        _audioSource.Play();

        Ray ray = new Ray(_firePoint.position, _firePoint.forward);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, _fireDistance,_layerMasks))
        {
            _particleSystemFirePoint.transform.position = hitInfo.point;
            _particleSystemFirePoint.transform.rotation = Quaternion.Euler(hitInfo.normal);
            _particleSystemFirePoint.Play();

            Debug.Log(hitInfo.collider.name);
            if (hitInfo.collider.TryGetComponent(out IDamageble component))
            {
                component.damage();
            }
            else if(hitInfo.collider.TryGetComponent(out Props props))
            {
                Vector3 force = hitInfo.point - _firePoint.position;
                props.AddForce(force,hitInfo.point);
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

        [SerializeField] private Rigidbody _rb;
    [SerializeField] private Vector3 _centerOfMass;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position + transform.rotation * _centerOfMass,0.05f);
    }
}
