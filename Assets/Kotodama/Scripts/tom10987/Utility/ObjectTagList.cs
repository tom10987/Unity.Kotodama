
using System.Collections.Generic;


public class ObjectTag {

  static public string player { get { return "Player"; } }
  static public string enemy { get { return "Enemy"; } }
  static public string ui { get { return "UI"; } }

  static List<string> _name = new List<string> {
    player,
    enemy,
    ui,
  };

  static public List<string> name { get { return _name; } }
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
