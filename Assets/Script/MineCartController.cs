using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineCartController : MonoBehaviour
{
    public Transform StartPoint;
    public Transform EndPoint;
    public float speed = 3f;

    private bool isMoving = true;

    void Update()
    {
        Transform target = isMoving ? EndPoint : StartPoint;

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, target.position) < 0.01f)
        {
            isMoving = !isMoving;
        }
    }
}
