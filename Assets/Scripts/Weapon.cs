using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Camera playerCamera;
    public Transform shootPoint;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shoot();
            Debug.Log("Gotcha!");
        }
    }

    void shoot()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        Vector3 target;
        if (Physics.Raycast(ray, out hit))
        {
            target = hit.point;
        }
        else
        {
            target = ray.GetPoint(75);
        }
        Vector3 shootDirection = target - shootPoint.position;
        GameObject realBullet = Instantiate(bullet, shootPoint.position, Quaternion.identity);
        realBullet.transform.forward = shootDirection.normalized;
        realBullet.GetComponent<Rigidbody>().AddForce(shootDirection.normalized * 10, ForceMode.Impulse);
    }
}