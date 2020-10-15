using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Shooting : MonoBehaviour
{
    public Camera MainCamera;
    public RaycastHit hit;
    private Vector3 destination;
    public GameObject projectile;
    public Transform Spawn_Point;
    public float range = 100;
    public float speed = 10f;
    public float fireRate = 4;
    public float timeToFire;
    public float arcRange = 1;
    public float range_O = 0.5f;
    public float range_I = 2f;
    public float damage = 10;
    [SerializeField] public LayerMask layerMask;

    private void Update()
    {

        if (Input.GetButton("Fire1") && Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1 / fireRate;
            Shoot();
        }

    }

    private void Shoot()
    {
        Ray ray = MainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        
        if (Physics.Raycast(ray, out hit))
        {
            destination = hit.point;
            Target_For_Shooting target = hit.transform.GetComponent<Target_For_Shooting>();          
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
        else
        {
            destination = ray.GetPoint(1000);
        }

        InstantiateProjectile();
    }
    void InstantiateProjectile()
    {   
        var projectileObj = Instantiate(projectile, Spawn_Point.position, Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - Spawn_Point.position).normalized * speed;

        iTween.PunchPosition(projectileObj, new Vector3(Random.Range(-arcRange, arcRange), Random.Range(-arcRange, arcRange), 0), Random.Range(range_O, range_I));
    }

}
