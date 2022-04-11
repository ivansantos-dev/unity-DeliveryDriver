
using UnityEngine;

public class Delivery : MonoBehaviour
{

    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] float destroyDelaySeconds = 0.5f;

    bool hasPackage;
    SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collided");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var tag = other.tag;

        if (tag == "Package" && !hasPackage)
        {
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelaySeconds);
        }
        else if (tag == "Customer" && hasPackage)
        {
            hasPackage = false;
                        spriteRenderer.color = noPackageColor;

        }
    }
}