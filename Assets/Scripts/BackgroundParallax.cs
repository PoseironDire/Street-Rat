using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    private float length, startposX, startposY;
    public GameObject cam;
    public float parallaxEffectX, parallaxEffectY;

    void Start()
    {
        startposX = transform.position.x;
        startposY = transform.position.y;

        length =GetComponent<SpriteRenderer>().bounds.size.x;
        
    }

    void Update()
    {
        float distX = (cam.transform.position.x * parallaxEffectX);
        float distY = (cam.transform.position.y * parallaxEffectY);

        transform.position = new Vector3(startposX + distX, startposY + distY, transform.position.z);
    }
}
