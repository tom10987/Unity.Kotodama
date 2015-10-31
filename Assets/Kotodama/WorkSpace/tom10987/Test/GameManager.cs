
using UnityEngine;


public class GameManager : MonoBehaviour {

  [SerializeField]
  Vector2 _start = Vector2.zero;

  [SerializeField]
  Vector2 _goal = Vector3.zero;

  GameObject _player = null;


  void Start() {
    _player = GameObject.Find("PlayerMover");
    _player.transform.position = _start;
  }

  void Update() {
  }
}
