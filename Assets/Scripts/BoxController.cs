using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    internal MeshRenderer meshRenderer;
    internal Score score;
    internal bool activated = false;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        score = GameObject.FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !activated)
        {
            PaintBox();            
        }
    }

    private void PaintBox() {
        score.boxesActivated++;
        meshRenderer.material.color = Color.red;
        activated = true;
    }

}
