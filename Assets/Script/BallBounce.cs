using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    public BallMovement ballMovement;
    public  ScoreManager scoreManager;

    public GameObject hitSFX;

    private void Bounce(Collision2D collision)
    {
        Vector3 ballPosition = transform.position;
        Vector3 racketPosition = collision.transform.position;
        float racketHeight = collision.collider.bounds.size.y;

        float positionX = 0;

        if( collision.gameObject.name == "Player 1")
        {
            positionX = 1;
        }
        else
        {
            positionX = -1;
        }

        float positionY = (ballPosition.y - racketPosition.y)/ racketHeight;

        ballMovement.hitCounters();
        ballMovement.MoveBall(new Vector2(positionX, positionY));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player 1" || collision.gameObject.name == "Player 2")
        {
            Bounce(collision);
        }
        else if (collision.gameObject.CompareTag("Left"))
        {
            if (scoreManager != null)
            {
                scoreManager.Player1Goal();
                ballMovement.player1Start = false;
                StartCoroutine(ballMovement.Launch());
            }
        }
        else if (collision.gameObject.CompareTag("Right"))
        {
            if (scoreManager != null)
            {
                scoreManager.Player2Goal();
                ballMovement.player1Start = true;
                StartCoroutine(ballMovement.Launch());
            }
        }

        GameObject hitSFXInstance = Instantiate(hitSFX, transform.position, transform.rotation);
        Destroy(hitSFXInstance, 1f);
    }
}
