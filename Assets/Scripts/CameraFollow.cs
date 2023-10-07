using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform objectToFollow;

    internal Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = objectToFollow.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = objectToFollow.transform.position - offset;
    }
}
