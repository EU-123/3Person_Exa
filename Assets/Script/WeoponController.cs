using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeoponController : MonoBehaviour
{
    [SerializeField] Weapon weapon;
    [SerializeField] KeyCode shootKey = KeyCode.H;
    [SerializeField] string enemyTag;

    private bool fire;

    void Update()
    {
        if (Input.GetKeyDown(shootKey))
        {
            fire = true;
        }

        if (Input.GetKeyUp(shootKey))
        {
            fire = false;
        }

        if (fire)
        {
            weapon.Fire(enemyTag);

            if (weapon.UseTap())
            {
                fire = false;
            }
        }
    }
}
