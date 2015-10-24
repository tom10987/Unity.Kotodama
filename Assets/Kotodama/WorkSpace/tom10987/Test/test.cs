
using UnityEngine;


public class test : MonoBehaviour {

  SceneSequencer _sequencer = null;
  

  void Start() {
    Debug.Log(Application.loadedLevelName);
    _sequencer = FindObjectOfType<SceneSequencer>();
  }

  void Update() {
    var isKeyDown = Input.GetKeyDown(KeyCode.Space);
    var isTouch = TouchController.IsTouchBegan();
    var isMainGame = Application.loadedLevelName == "Chapter1";
    if (isMainGame && !TouchController.IsPushedQuitKey()) { return; }
    if (isKeyDown || isTouch) { _sequencer.SceneFinish(); }
  }
}
