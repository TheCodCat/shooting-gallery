using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47 : Gun
{
    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Fire();
        }
    }
    public override void Fire()
    {
        if (!_isFire) return;


        Ray ray = new Ray(_firePoint.position,_firePoint.forward);

        if(Physics.Raycast(ray,out RaycastHit hitInfo, _fireDistance))
        {
            Debug.DrawRay(ray.origin,ray.direction * hitInfo.distance,Color.red);
            if (hitInfo.collider.TryGetComponent(out Idamageble component))
            {
                component.damage(_damage);
            }
        }
        IsFire().AsAsyncUnitUniTask();
    }

    public override void Reload()
    {

    }
}
