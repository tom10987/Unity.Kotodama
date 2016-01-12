
using UnityEngine;


/// <summary> ゲームの進行状態 </summary>
public enum GameState { Start, Clear, Max, }


public class GameManager : SingletonBehaviour<GameManager> {

  public GameState phone { get; set; }
  public GameState manhole { get; set; }
  public GameState labyrinth { get; set; }

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
    labyrinth = manhole = phone = GameState.Start;
    isPause = false;
    playerStartPosition = Vector3.zero;
  }
}
