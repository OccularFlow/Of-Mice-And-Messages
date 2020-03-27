using UnityEngine;

public class SelectionBox : MonoBehaviour
{
    private SpriteRenderer s;

    private void Start()
    {
        s = GetComponent<SpriteRenderer>();
        s.enabled = false;
    }
    public void move(Vector3 pos)
    {
        transform.position = pos;
        s.enabled = true;
    }
    public void remove()
    {
        s.enabled = false;
    }
}
