using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float startSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float acceleration;

    public bool player1Start = true;

    private float hitCounter = 0;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Launch());
    }

    private void RestartBall()
    {
        rb.velocity = new Vector2(0,0);
        transform.position = new Vector2(0, 0);
    }

    public IEnumerator Launch()
    {
        RestartBall();
        hitCounter= 0;
        yield return new WaitForSeconds(1);

        if (player1Start == true) {

            MoveBall(new Vector2(-1, 0));
        }
        else
        {

            MoveBall(new Vector2(1, 0));
        }

    }

    public void MoveBall(Vector2 direction)
    {
        direction = direction.normalized;
        float ballSpeed = startSpeed + hitCounter * acceleration;

        rb.velocity = direction * ballSpeed;
    }

    public void hitCounters()
    {
        if(hitCounter * acceleration< maxSpeed)
        {
            hitCounter++;
        }
    }
}
