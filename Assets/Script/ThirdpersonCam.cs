using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdpersonCam : MonoBehaviour
{
    [SerializeField] Transform oriantaion;
    [SerializeField] Transform player;
    [SerializeField] Transform playerObj;
    [SerializeField] Rigidbody RB;

    [SerializeField] float ratationSpeed;

    [SerializeField] Transform lookAt;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        oriantaion.forward = viewDir.normalized;

        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");
        //Vector3 inputDir = oriantaion.forward * verticalInput + oriantaion.right * horizontalInput;

        //if(inputDir != Vector3.zero)
        //{
        //playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * ratationSpeed);
        //}

        Vector3 dirToLookAt = lookAt.position - new Vector3(transform.position.x, lookAt.position.y, transform.position.z);
        oriantaion.forward = dirToLookAt.normalized;

        playerObj.forward = dirToLookAt.normalized;
    }
}
