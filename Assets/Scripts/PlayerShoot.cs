using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Camera playerCamera;
    public GameObject bulletPrefab;
    public GameObject bulletHole;
    public GameObject gun;
    public float fire_rate = 1f;
    private bool allowfire = true;
    private float last_shot = 0f;
    private Vector3 originalRotation;
    public Vector3 upRecoil;
    // Start is called before the first frame update
    void Start()
    {
        originalRotation = gun.transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (allowfire == false && Time.time > last_shot + fire_rate) {
            ResetRecoil();
            allowfire = true;
        }
        if (Input.GetButton("Fire1") && allowfire)
        {
            last_shot = Time.time;
            Fire();
            allowfire = false;
        }
    }
    void AddRecoil() {
        gun.transform.localEulerAngles = upRecoil;
    }
    void ResetRecoil() {
        gun.transform.localEulerAngles = originalRotation;
    }
    void Fire()
    {
        GameObject bulletObject = Instantiate(bulletPrefab);
        bulletObject.transform.position = bulletHole.transform.position + playerCamera.transform.forward;
        bulletObject.transform.forward = bulletHole.transform.forward;
        AddRecoil();
    }
}
