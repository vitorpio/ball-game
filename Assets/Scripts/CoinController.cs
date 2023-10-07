using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    internal Score score;
    internal float rotateSpeed = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.down * rotateSpeed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CollectCoin();
        }
    }

    private void CollectCoin()
    {
        score.coinsCollected++;
        Destroy(gameObject);
    }

}
