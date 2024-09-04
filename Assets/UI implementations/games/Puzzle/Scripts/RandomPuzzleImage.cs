using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPuzzleImage : MonoBehaviour
{
    [SerializeField] Sprite[] images;
    [SerializeField] GameObject[] pieces;
    void Start()
    {
        AssignRandomImage();
    }

    void AssignRandomImage()
    {
        Sprite randomSprite = images[Random.Range(0, images.Length)];
    
        foreach (GameObject piece in pieces)
        {
            SpriteRenderer childSpriteRenderer = piece.transform.Find("PuzzleImage").GetComponent<SpriteRenderer>();
            childSpriteRenderer.sprite = randomSprite;
        }  
    }
    
    void Update()
    {
        
    }
}
