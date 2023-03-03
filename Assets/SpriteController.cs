using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    [SerializeField]
   SpriteRenderer spriteRenderer;

    Sprite beatBody;
    Sprite beatCircleIndicator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAlpha(float value)
    {

        Color color = spriteRenderer.color;

        color.a = value;
        spriteRenderer.color = color;
    }

    public void SpawnIndicator()
    {

    }
    public void DestroyIndicator()
    {

    }
    public void ChangeSpriteToCriticalState()
    {
        spriteRenderer.color = Color.grey;
    }

    public void ChangeSpriteToNormal()
    {
        spriteRenderer.color = Color.yellow;
    }

}
