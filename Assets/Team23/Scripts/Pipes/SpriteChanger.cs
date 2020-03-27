using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    [SerializeField] private Sprite[] pipeSprites;
    private SpriteRenderer spriteRenderer;
    private int currentSprite = 0;

    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void rotateClockwise() {
        currentSprite = (currentSprite + 1) % pipeSprites.Length;
        spriteRenderer.sprite = pipeSprites[currentSprite];
    }
    public void rotateAnticlockwise() {
        currentSprite = (currentSprite + pipeSprites.Length - 1) % pipeSprites.Length;
        spriteRenderer.sprite = pipeSprites[currentSprite];
    }
}
