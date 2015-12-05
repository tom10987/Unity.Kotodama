
using UnityEngine;


public class GameManager : SingletonBehaviour<GameManager> {

  public bool isPause { get; set; }

  protected override void Awake() {
    //TODO: シーンが変わってもオブジェクトが残るようにする
    DontDestroyOnLoad(gameObject);
  }
}
