using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public UnityEvent Landed;
    public UnityEvent Dead;

    [SerializeField] private float JumpForce;
    [SerializeField] private ContactFilter2D platform;

    private Rigidbody2D RigidBody;
    private bool isOnPlatform => RigidBody.IsTouching(platform);

    private void Awake()
    {
        RigidBody = GetComponent<Rigidbody2D>();
    }

    public void Jump() 
    {
        if(isOnPlatform)
        RigidBody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject CollisionObject = collision.gameObject;

        if (CollisionObject.transform.parent != null)
            if (CollisionObject.transform.parent.TryGetComponent(out Platform platform))
                platform.StopMovement();

        if (CollisionObject.CompareTag("PlatformWall"))
            Dead?.Invoke();
        else if (CollisionObject.CompareTag("Platform"))
        {
            CollisionObject.tag = "Untagged";
            Landed?.Invoke();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
