using UnityEngine;

public class Keg : MonoBehaviour
{
    [SerializeField] float launchStength;
    Rigidbody2D rb;

    public void Launch()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector3.left * launchStength);
    }
}
