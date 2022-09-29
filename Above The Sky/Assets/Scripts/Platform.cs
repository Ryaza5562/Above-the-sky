using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float StartMoveSpeed = 8f;
    [SerializeField] private float SpeedOffset = 0.2f;

    private GameObject Player;
    private float MoveSpeed;
    private int MoveDirection;
    private bool HasToMove = true;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        MoveDirection = transform.position.x < Player.transform.position.x ? 1 : -1;
    }

    public void StopMovement() => HasToMove = false;

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HasToMove)
        {
            float Score = float.Parse(GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>().text);
            MoveSpeed = StartMoveSpeed + Score * SpeedOffset;
            transform.position += Vector3.right * MoveDirection * MoveSpeed * Time.deltaTime;
        }
    }
}
