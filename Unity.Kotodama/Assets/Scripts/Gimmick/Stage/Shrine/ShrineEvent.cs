
using UnityEngine;

public class ShrineEvent : MonoBehaviour {

  void Start() {
    PlayerState.instance.transform.position = GameManager.instance.start;
  }
}
