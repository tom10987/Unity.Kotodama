
using UnityEngine;


public class GameManager : SingletonBehaviour<GameManager> {

  EnemyManager enemy { get { return EnemyManager.instance; } }

  public bool isPause { get; private set; }
  public Vector3 playerStartPosition { get; set; }


  public void Pause() {
    isPause = true;
    if (enemy != null) { enemy.SwitchEnemiesState(); }
  }

  public void ReStart() {
    isPause = false;
    if (enemy != null) { enemy.SwitchEnemiesState(); }
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
