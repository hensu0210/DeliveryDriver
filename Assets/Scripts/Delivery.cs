using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    [SerializeField] float delayDestroy = 1f;
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    SpriteRenderer spriteRenderer;

    private void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Ouch!");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Package" && !hasPackage)
        {
            hasPackage = true;
            Debug.Log("Package Pick");
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, delayDestroy);
        }

        if(other.tag == "Customer" && hasPackage)
        {
            hasPackage = false;
            Debug.Log("Package take");
            spriteRenderer.color = noPackageColor;
        }
    }
}
