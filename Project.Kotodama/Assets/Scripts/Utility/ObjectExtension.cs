
/// <summary> ゲーム内で使用しているオブジェクトのタグ一覧 </summary>
public enum ObjectTag {
  Untagged,

  Player,
  Enemy,

  Ground,
  NavObstacle,

  Gimmick,
  Item,
  Adventure,

  Field,
  UI,

  Max,
}

public static class ObjectExtension {
  public static bool EqualTo(this ObjectTag tag, string tagName) { return tag.ToString() == tagName; }
}
