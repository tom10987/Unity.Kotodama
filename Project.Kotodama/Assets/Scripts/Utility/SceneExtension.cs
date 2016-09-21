
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

/// <summary> インデックス付きのビルド対象シーンの一覧 </summary>
public enum GameScene {
  GameManager,
  Title,
  Tutorial,
  Shrine,
  PhoneBooth,
  Manhole,
  Labyrinth,
  Ending,

  Max, None = -1,
}

public static class SceneExtension {

  static string gameManager { get { return GameScene.GameManager.ToString(); } }

  /// <summary> シーンの状態を初期化する </summary>
  public static void Reset(this GameScene scene) {
    SceneManager.LoadScene(gameManager, LoadSceneMode.Single);
    scene.Additive();
    //SceneManager.SetActiveScene();
  }

  public static void ChangeScene(this GameScene scene) {
    var game = GameManager.instance;
    game.previous = game.current;
    game.current = scene;
    SceneManager.LoadScene(scene.ToString());
  }

  static IEnumerable<Scene> GetAllActiveScenes() {
    var count = SceneManager.sceneCount;
    for (var index = 0; index < count; ++index) { yield return SceneManager.GetSceneAt(index); }
  }

  static bool Additive(this GameScene scene) {
    var target = scene.ToString();
    var find = GetAllActiveScenes().Any(loaded => loaded.name == target);
    if (find) { SceneManager.LoadScene(target, LoadSceneMode.Additive); }
    return find;
  }

  static bool Unload(this GameScene scene) {
    var success = SceneManager.UnloadScene(scene.ToString());
    if (success) { GameManager.instance.previous = scene; }
    return success;
  }
}
