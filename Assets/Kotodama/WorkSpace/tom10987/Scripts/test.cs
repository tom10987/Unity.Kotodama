
using UnityEngine;


public class test : MonoBehaviour {

  void Update() {
    if (Input.GetKeyDown(KeyCode.Space)) {
      FindObjectOfType<SceneSequencer>().SceneFinish();
    }
  }
}
