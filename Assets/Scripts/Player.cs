using UnityEngine;

public class Player : MonoBehaviour {

    public GamePlayController playController;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.scoreCount++;

        if (collision.gameObject.tag == "Obstacle")
        {
            playController.playerRigidbody2D.AddTorque(playController.playerRigidbody2D.velocity.x); // twist the ball after he touched platforms or floor
            playController.playerRigidbody2D.velocity = new Vector2(0f, playController.planetData[0].gravity); // stop ball after he touched platforms or floor
        }
    }
}
