using UnityEngine;

public class StartPipe : MonoBehaviour
{
    private Vector3 waterSource;
    public static readonly float waterDropRate = 0.06f;
    private bool waterRunning = false;
    int dropletCount = 0;

    public void toggleWater() {
        waterRunning = !waterRunning;
        if (waterRunning) {
            InvokeRepeating("dropWater", 0.05f, StartPipe.waterDropRate);
        } else {
            CancelInvoke();
        }
    }

    void Start() {
        waterSource = this.transform.position;
    }

    void dropWater() {
        GameObject newDrop;
        if (dropletCount > 15) {
            dropletCount = 0;
            newDrop = DropletPool.instance.tryToGetBottleDroplet(); 
        } else {
            dropletCount++;
            newDrop = DropletPool.instance.getDroplet();
        }
        float randRange = 0.01f;
        
        float random = Random.Range(-randRange,randRange);
        newDrop.transform.position = new Vector2(waterSource.x + random, waterSource.y);
        newDrop.SetActive(true);
        newDrop.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -3);

    }

}
