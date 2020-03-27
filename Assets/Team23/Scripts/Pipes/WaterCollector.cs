using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class WaterCollector : MonoBehaviour
{
    private Pipe pipe;
    void Start()
    {
        pipe = GetComponentInParent<Pipe>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if (pipe.collectWater(collision.gameObject.GetComponent<Rigidbody2D>().velocity, this.tag))
        //     Destroy(collision.gameObject, 0.1f);
        if (pipe.collectWater(collision.gameObject, this.tag)) {
            // StartCoroutine(destroyWater(collision.gameObject));
            collision.gameObject.SetActive(false);

        }
    }

    IEnumerator destroyWater(GameObject water){
        yield return new WaitForSeconds(0.08f);
        water.SetActive(false);
    }

}
