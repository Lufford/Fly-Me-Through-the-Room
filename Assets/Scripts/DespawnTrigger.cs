
using UnityEngine;

public class DespawnTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Crumb")
        {
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var collisionTag = collision.gameObject.tag;
        if (collisionTag == "ElectricFan" || collisionTag == "BugLamp")
        {
            Destroy(collision.gameObject);
        }
    }
}
