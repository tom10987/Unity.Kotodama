
using UnityEngine;


public class PlayerDead : MonoBehaviour {

  public void OnTriggerEnter(Collider collision) {
    if (collision.gameObject.tag != "Player") { return; }
    FindObjectOfType<SceneSequencer>().SceneFinish("Epilogue");
    collision.GetComponent<Rigidbody>().velocity = Vector2.zero;
    GetComponentInParent<Rigidbody>().velocity = Vector2.zero;
  }
}
