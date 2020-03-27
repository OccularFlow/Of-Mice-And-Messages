using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeRotator : MonoBehaviour
{
    public void rotateClockwise() {
        transform.Rotate(Vector3.forward * -90);
    }
    public void rotateAnticlockwise() {
        transform.Rotate(Vector3.forward * 90);
    }
}
