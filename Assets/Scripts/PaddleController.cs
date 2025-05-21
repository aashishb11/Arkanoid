using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PaddleController : MonoBehaviour
{
    public float speed = 10f; //for the speed per second 
    public float edgeBuffer = 0.01f;
    private float leftClamp;
    private float rightClamp;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Transform leftWall  = GameObject.Find("Wall_Left").transform;
        Transform rightWall = GameObject.Find("Wall_Right").transform;
        float leftInnerX  = leftWall.position.x  + leftWall.localScale.x * 0.5f;
        float rightInnerX = rightWall.position.x - rightWall.localScale.x * 0.5f;

        float halfPaddle = transform.localScale.x * 0.5f;

        leftClamp  = leftInnerX  + halfPaddle + edgeBuffer;
        rightClamp = rightInnerX - halfPaddle - edgeBuffer;
    }

    void Update()
    {
        float input  = Input.GetAxisRaw("Horizontal"); // move by A D or Left Right Arrows 
        Vector3 next = rb.position + Vector3.right * input * speed * Time.fixedDeltaTime;
    next.x = Mathf.Clamp(next.x, leftClamp, rightClamp);
    rb.MovePosition(next);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
}
