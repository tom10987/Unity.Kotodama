
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary> ユーザー定義を含む、プロジェクトで有効なレイヤー一覧 </summary>
public enum Layer {
  Player,
  Enemy,

  Ground,
  NavObstacle,

  Gimmick,
  Item,
  Adventure,

  Max, None = -1,
}

public static class LayerExtension {

  /// <summary> プロジェクトで使用しているレイヤー数を取得 </summary>
  public static int max { get { return (int)Layer.Max; } }

  /// <summary> プロジェクトで使用している全てのレイヤー名を取得 </summary>
  public static IEnumerable<string> layerNames {
    get { return Enum.GetNames(typeof(Layer)).Take(max); }
  }

  public static bool EqualTo(this Layer layer, LayerMask mask) {
    return layer.GetIndex() == mask.value;
  }

  /// <summary> エディターで管理しているレイヤー番号を取得 </summary>
  public static int GetIndex(this Layer layer) {
    return LayerMask.NameToLayer(layer.ToString());
  }
}
