using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public void LaunchProjectile(GameObject projectilePrefab, Vector3 direction, float speed, Vector3 startPos)
    {
        GameObject newProj = Instantiate(projectilePrefab);
        newProj.transform.position = startPos;
        Rigidbody2D rigidbody = newProj.GetComponent<Rigidbody2D>();

        rigidbody.velocity = direction.normalized * speed;
    }
}
