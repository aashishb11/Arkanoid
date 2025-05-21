using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    public float launchSpeed = 12f;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

 void Start()
{
    Vector3 dir = new Vector3(Random.Range(-0.5f, 0.5f), 0f, 1f).normalized;
    rb.velocity = dir * launchSpeed;   
    Debug.Log($"Ball launched! velocity = {rb.velocity}");
}

    void OnCollisionExit(Collision col)
    {
        Vector3 v = rb.velocity;
        v.y = 0f;
        rb.velocity = v;
    }
}
