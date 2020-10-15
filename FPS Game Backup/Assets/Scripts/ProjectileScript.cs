using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private bool collided;
    public GameObject player;
    public RaycastHit ImpactPoint;
    private void Start()
    {
        ImpactPoint = player.GetComponent<Shooting>().hit;
        print(ImpactPoint);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "Player" && !collided)
        {
            print("Hi " + ImpactPoint);
            collided = true;
            Destroy(gameObject);
        }
    }


}
