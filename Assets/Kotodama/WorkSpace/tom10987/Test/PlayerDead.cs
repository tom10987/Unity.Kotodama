
using UnityEngine;


public class PlayerDead : MonoBehaviour {

  public void OnTriggerEnter2D(Collider2D collision) {
    if (collision.gameObject.tag != "Player") { return; }
    FindObjectOfType<SceneSequencer>().SceneFinish("Epilogue");
    collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    GetComponentInParent<Rigidbody2D>().velocity = Vector2.zero;
  }
}
