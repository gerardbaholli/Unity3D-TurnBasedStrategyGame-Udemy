using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{

    [SerializeField] private TrailRenderer trailRenderer;
    [SerializeField] private GameObject bulletHitVFXPrefab;

    private Vector3 targetPosition;

    public void Setup(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }

    private void Update()
    {
        Vector3 moveDirection = (targetPosition - transform.position).normalized;

        float distaceBeforeMoving = Vector3.Distance(targetPosition, transform.position);

        float moveSpeed = 200f;
        transform.position += moveSpeed * Time.deltaTime * moveDirection;

        float distaceAfterMoving = Vector3.Distance(targetPosition, transform.position);

        if (distaceBeforeMoving < distaceAfterMoving)
        {
            transform.position = targetPosition;
            trailRenderer.transform.parent = null;
            Destroy(gameObject);
            Instantiate(bulletHitVFXPrefab, targetPosition, Quaternion.identity);
        }

    }

}
