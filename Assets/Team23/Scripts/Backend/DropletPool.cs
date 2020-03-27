using System.Collections.Generic;
using UnityEngine;

public class DropletPool : MonoBehaviour
{
   public static DropletPool instance;
   [SerializeField] private GameObject dropletObject;
   [SerializeField] private GameObject bottle;
    private GameObject bottleDroplet;

   private bool isBottleLost = true;

   [SerializeField] private int numOfDrops = 50;
   private List<GameObject> pooledDroplets;

    void Awake() {
        instance = this;
    }
   void Start() {
       pooledDroplets = new List<GameObject>();

       GameObject newDrop;
       for (int i = 0; i < numOfDrops/2 ; i++) {
            newDrop = Instantiate(dropletObject);
            newDrop.SetActive(false);
            pooledDroplets.Add(newDrop);
       }
        bottleDroplet = Instantiate(dropletObject);
        GameObject messageBottle = Instantiate(bottle);
        bottleDroplet.tag = "message bottle";
        messageBottle.transform.parent = bottleDroplet.transform;
        messageBottle.transform.position.Set(0,0,0);
        bottleDroplet.SetActive(false);
   }

    public GameObject getDroplet() {
        for (int i = 0; i < pooledDroplets.Count; i++) {
            if (!pooledDroplets[i].activeInHierarchy) {
                return pooledDroplets[i]; 
            }
        }
        GameObject newDrop = Instantiate(dropletObject);
        newDrop.SetActive(false);
        pooledDroplets.Add(newDrop);
        return newDrop;
    }

    public GameObject getBottleDroplet() {
        return bottleDroplet;
    }

    public GameObject tryToGetBottleDroplet() {
        if (isBottleLost) {
            isBottleLost = false;
            return bottleDroplet;
        }
        return getDroplet();
    }

    public void bottleLost() {
        isBottleLost = true;
    }

}
