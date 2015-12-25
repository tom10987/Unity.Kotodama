
using UnityEngine;


public class GameManager : SingletonBehaviour<GameManager> {

  public bool isPause { get; set; }

  protected override void Awake() {
    base.Awake();
    DontDestroyOnLoad(gameObject);
  }

  void Start() {
    isPause = false;
  }
}
