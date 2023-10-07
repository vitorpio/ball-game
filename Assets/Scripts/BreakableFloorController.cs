using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableFloorController : MonoBehaviour
{
    public Material materialFloor2;
    public Material materialFloor1;

    internal int life = 3;
    internal MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            BreakFloor();
        }
    }

    private void BreakFloor()
    {
        life--;
        switch (life)
        {
            case 2:
                meshRenderer.material = materialFloor2;
                break;
            case 1:
                meshRenderer.material = materialFloor1;
                break;
            case 0:
                Destroy(gameObject);
                break;

            default:
                break;
        }
    }

}
