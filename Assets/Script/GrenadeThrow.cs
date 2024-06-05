using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class GrenadeThrow : MonoBehaviour
{
    [SerializeField] Transform plOritation;
    [SerializeField] Transform attckPoint;
    [SerializeField] GameObject grenade;

    [SerializeField] float throwCooldown;

    [SerializeField] KeyCode throwKey = KeyCode.T;
    [SerializeField] float throwForce;
    [SerializeField] float throwUpwardsForce;

    bool readyToThrow;

    private void Start()
    {
        readyToThrow = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(throwKey) && readyToThrow)
        {
            Throw();
        }
    }

    void Throw()
    {
        readyToThrow = false;

        GameObject projectile = Instantiate(grenade, attckPoint.position, plOritation.rotation);

        Rigidbody projectileRB = projectile.GetComponent<Rigidbody>();

        Vector3 forceAdd = plOritation.transform.forward * throwForce + transform.up * throwUpwardsForce;

        projectileRB.AddForce(forceAdd, ForceMode.Impulse);

        Invoke(nameof(ResetThrow), throwCooldown);
    }

    void ResetThrow()
    {
        readyToThrow = true;
    }
}
