using UnityEngine;
using UnityEngine.UI;

public class RandomSprites : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    private void Start()
    {
        spriteRenderer.sprite = sprites[Random.Range(0,sprites.Length)];
    }
}
