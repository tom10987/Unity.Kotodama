
/// <summary> ゲーム内で使用しているオブジェクトのタグ一覧 </summary>
public enum ObjectTag {
  Player,
  Enemy,

  UI,
  Gimmick,
  Item,
  Adventure,

  Ground,
  NavObstacle,

  Max,
}

public static class ObjectExtension {
  public static bool EqualTo(this ObjectTag tag, string tagName) { return tag.ToString() == tagName; }
}
