
using System.Collections.Generic;


public class ObjectTag {

  public const string player = "Player";
  public const string enemy = "Enemy";
  public const string ui = "UI";

  public const string gimmick = "Gimmick";
  public const string item = "Item";
}


public class SceneTag {

  static public string title { get { return "Title"; } }
  static public string prologue { get { return "Prologue"; } }
  static public string mainGame { get { return "MainGame"; } }
  static public string epilogue { get { return "Epilogue"; } }

  static List<string> _name = new List<string> {
    title,
    prologue,
    mainGame,
    epilogue,
  };

  static public List<string> name { get { return _name; } }
}
