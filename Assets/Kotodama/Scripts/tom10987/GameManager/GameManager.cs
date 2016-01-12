
using UnityEngine;


public class GameManager : SingletonBehaviour<GameManager> {

  public bool isPause { get; private set; }
  public Vector3 playerStartPosition { get; set; }


  public void SwitchPause() {
    isPause = !isPause;
    EnemyManager.instance.SwitchEnemiesState(!isPause);
  }

  protected override void Awake() {
    base.Awake();
    DontDestroyOnLoad(gameObject);
  }

  public void Initialize() {
    isPause = false;
    playerStartPosition = Vector3.zero;
  }
}
