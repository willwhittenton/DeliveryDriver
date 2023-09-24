using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    
    [SerializeField] float destroyTimer = 0.5f;
    bool hasPackage;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("You bumped into something!");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
         if (other.tag == "Package" && !hasPackage)
         {
            Debug.Log("Package picked up");
            hasPackage = true;
            Destroy(other.gameObject, destroyTimer);
            spriteRenderer.color = hasPackageColor;
         }
         if (other.tag == "Customer" && hasPackage)
         {
            Debug.Log("Package delivered to customer");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
         }

    }
}
