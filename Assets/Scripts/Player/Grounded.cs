using UnityEngine;

namespace Player
{
    public class Grounded : MonoBehaviour
    {
        GameObject Player;
        void Start()
        {
            Player = gameObject.transform.parent.gameObject;
        }

        void Update()
        {
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            if (collision.collider.tag == "Ground"){
                Player.GetComponent<PlayerMovement>().isGrounded = true;
            }
        }

        private void OnCollisionExit2D(Collision2D collision) {
            if (collision.collider.tag == "Ground"){
                Player.GetComponent<PlayerMovement>().isGrounded = false;
            }
        
        }
    }
}
