
using System.Collections.Generic;


public class Scenario {

  const string None = "";
  const string Mari = "マリ";
  const string Nana = "ナナ";

  public struct SceneData {
    public SceneData(string name, string text) { this.name = name; this.text = text; }
    public string name { get; set; }
    public string text { get; set; }
  }

  static public readonly SceneData[] sceneData = new SceneData[] {
    new SceneData(None, ""),
  };
}
