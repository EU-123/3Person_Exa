using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] float damage;

    [SerializeField] float fireRate;

    [SerializeField] float fireDistance = 10;

    [SerializeField] Transform bulletPoint;

    private RaycastHit hit;

    private bool cooldown;

    public void Fire(string enemyTag)
    {
        if (cooldown) return;

        Ray ray = new Ray();
        ray.origin = bulletPoint.position;
        ray.direction = bulletPoint.TransformDirection(Vector3.forward);

        Debug.DrawRay(ray.origin, ray.direction * fireDistance, Color.green);

        if (Physics.Raycast(ray, out hit, fireDistance))
        {
            if (hit.collider.CompareTag(enemyTag))
            {
                var healthCtrl = hit.collider.GetComponent<HealthControler>();
                healthCtrl.ApplyDamage(damage);
            }
        }

        cooldown = true;
        StartCoroutine(StopCooldownAfterTime());
    }

    private IEnumerator StopCooldownAfterTime()
    {
        yield return new WaitForSeconds(fireRate);
        cooldown = false;
    }

    public bool UseTap()
    {
        return fireRate == 0;
    }
}
