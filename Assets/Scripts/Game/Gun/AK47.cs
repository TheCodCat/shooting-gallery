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
    public override void Reload()
    {

    }
}
