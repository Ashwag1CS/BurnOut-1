using UnityEngine;

public class Pencil_Script : MonoBehaviour
{
    [SerializeField]
    private float speed=5f; // Actual speed of this specific item

    [SerializeField]
    private float _lifetime = 10.0f; // Lifetime for each pencil

    private void Start()
    {
      

        // Destroy pencil after its lifetime expires
        Destroy(gameObject, _lifetime);
    }

    private void Update()
    {    // Move the negative item downwards
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Reset position if it goes off-screen
        if (transform.position.y < -5f)
        {
            ResetPosition();
        }
    }

    private void ResetPosition()
    {
        // Move the pencil to a random position at the top of the screen
        float randomX = Random.Range(-8f, 8f);
        transform.position = new Vector3(randomX, 7, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the pencil collides with the player
        if (other.CompareTag("Player"))
        {
            // Access PlayerMove component on the player to increase points
            PlayerMove playerMove = other.GetComponent<PlayerMove>();
            if (playerMove != null)
            {
                playerMove.PlayerPoints(); // Increase points
            }

            Destroy(this.gameObject); // Destroy the pencil after it's collected
        }
    }
}
