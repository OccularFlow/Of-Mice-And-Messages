using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridEdge : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SetActive(false);
        if (collision.tag == "message bottle") {
            DropletPool.instance.bottleLost();
        }
    }   
}
