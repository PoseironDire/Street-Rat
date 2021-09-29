using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerPosition;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;
    public float dampTime = 0.15f;

    void FixedUpdate()
    {
        // transform.position = new Vector3(playerPosition.position.x + offset.x, playerPosition.position.y + offset.y, offset.z); //Locked camera movement

        if (playerPosition)
        {
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(playerPosition.position);
            Vector3 delta = playerPosition.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = new Vector3(playerPosition.position.x + offset.x, playerPosition.position.y + offset.y, offset.z) + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }
}