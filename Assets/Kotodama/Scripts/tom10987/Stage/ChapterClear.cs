
using UnityEngine;


public class ChapterClear : MonoBehaviour {

  public void OnTriggerEnter(Collider collider) {
    if (!ItemManager.hasItem) { return; }
    FindObjectOfType<SceneSequencer>().SceneFinish("Epilogue");

    var rigidBody = collider.GetComponent<Rigidbody>();
    rigidBody.velocity = Vector3.zero;
  }
}
