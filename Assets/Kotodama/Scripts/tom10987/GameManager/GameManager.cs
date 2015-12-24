
using UnityEngine;


public class GameManager : SingletonBehaviour<GameManager> {

  protected override void Awake() {
    base.Awake();
    DontDestroyOnLoad(gameObject);
  }

  void Start() {
  }
}
