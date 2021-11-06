using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 8.0f;
    public float speedMultiplier = 1.0f;
    public Vector2 initialDirection;
    public LayerMask obstacleLayer;

    public Vector2 direction { get; private set; }
    public Vector2 nextDirection { get; private set; }
    public Vector3 startingPosition { get; private set; }

    private bool isMoving = false;

    private void Awake()
    {
        
        this.startingPosition = this.transform.position;
    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        this.speedMultiplier = 1.0f;
        this.direction = this.initialDirection;
        this.nextDirection = Vector2.zero;
        this.transform.position = this.startingPosition;
        this.enabled = true;
    }

    private void Update()
    {

        
        if(direction != Vector2.zero)
        {
            Vector2 dest = FindDestination(direction);
            if (dest != Vector2.zero)
            {
                this.transform.position = new Vector3(dest.x, dest.y, -0.01f);

            }
        }

    }

    

    public void SetDirection(Vector2 direction)
    {
        if (isMoving)
        {
            this.nextDirection = direction;
        }
        else {
            this.direction = direction;
        }
    }

    public bool Occupied(Vector2 direction)
    {
        // If no collider is hit then there is no obstacle in that direction
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.75f, 0.0f, direction, 1.5f, this.obstacleLayer);
        return hit.collider != null;
    }

    public Vector2 FindDestination(Vector2 direction)
    {
        
        RaycastHit2D[] hit = Physics2D.RaycastAll(this.transform.position, direction);
        if(hit.Length > 1)
        {
            return hit[1].transform.position;
        }
        Debug.Log(hit.Length);
        return Vector2.zero;
    }
}
