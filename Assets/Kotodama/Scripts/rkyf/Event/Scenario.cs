
using UnityEngine;
using System.Collections.Generic;


public class CharacterSprite {

  static Sprite _mari = null;
  static public Sprite mari {
    get {
      if (_mari == null) { _mari = Resources.Load<Sprite>(""); }
      return _mari;
    }
  }

  static Sprite _nana = null;
  static public Sprite nana {
    get {
      if (_nana == null) { _nana = Resources.Load<Sprite>(""); }
      return _nana;
    }
  }

  static readonly Dictionary<string, Sprite> _sprite = new Dictionary<string, Sprite> {
    { Scenario.Mari, _mari }, { Scenario.Nana, _nana },
  };

  /// <summary> キーが一致しなければ null を返す </summary>
  static public Sprite GetSprite(string name) {
    var isValid = _sprite.ContainsKey(name);
    return isValid ? _sprite[name] : null;
  }
}


public class Scenario {

  public const string None = "";
  public const string Mari = "マリ";
  public const string Nana = "ナナ";

  public struct TextData {
    public TextData(string name, string text) { this.name = name; this.text = text; }
    public string name { get; set; }
    public string text { get; set; }
  }

  public enum StoryName {
    None,

    Prologue,
    Tutorial,
  }

  static public readonly TextData[] prologue = new TextData[] {
    new TextData(None, ""),
  };

  static public readonly TextData[] tutorial = new TextData[] {
    new TextData(None, ""),
  };
}
