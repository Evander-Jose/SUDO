using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProjectileLauncher))]
public class PlayerProjectileLauncher : MonoBehaviour
{
    private ProjectileLauncher projectileLauncher;
    public GameObject projectilePrefab;
    public float projectileFireSpeed = 5f;

    private void Start()
    {
        projectileLauncher = GetComponent<ProjectileLauncher>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            projectileLauncher.LaunchProjectile(projectilePrefab, transform.right, projectileFireSpeed, transform.position);
        }
    }
}
