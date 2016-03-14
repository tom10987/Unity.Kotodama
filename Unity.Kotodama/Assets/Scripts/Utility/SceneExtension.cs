
using UnityEngine.SceneManagement;

public enum SceneTag {
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
  public static void ChangeScene(this SceneTag tag) { SceneManager.LoadScene(tag.ToString()); }
}
