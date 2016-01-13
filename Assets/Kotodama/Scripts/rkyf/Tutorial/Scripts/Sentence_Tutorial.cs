using UnityEngine;
using System.Collections;

using static CharaName;
using static Command;

public class Sentence_Tutorial : MonoBehaviour
{
    EventState Tutorial = null;

	void Start ()
    {
        Tutorial = this.gameObject.GetComponentInChildren<EventState>();
	
	}
	void Update ()
    {
	
	}

    public string[,] Sentence =
    {
        { start, "", "", "" },
        { act, "GameStart", "", "" },
        { Command.name, narrator, "" , ""},
        { text, "マリという少女がいた。", "", "" },
        { text, "彼女は学校で独りぼっち。", "", "" },
        { text, "それが原因で部屋から出なくなった。", "", "" },
        { text, "それから彼女は「夢」に囚われるようになった。", "", "" },
        { text, "「夜」の夢を。", "", "" },
        { text, "彼女は「暗夜の夢」に囚われ、そしてランタンを手にした。", "", "" },

    };

    
    public string[,] Sentence2 =
    {
        { start, "", "", "" },
        { act, "StageStart", "", "" },
        { Command.name, mari,"","" },
        { text, "少しは…明るくなったかな","",""},
        { Command.name, nana,"","" },
        { text, "だーれ？","",""},
        { Command.name, mari,"","" },
        { text, "………………","",""},
        { text, "火がしゃべってる…？","",""},
        { Command.name, nana,"","" },
        { text, "あんまり驚かないんだね","",""},
        { Command.name, mari,"","" },
        { text, "…だって、ここは私の夢の中でしょう？","",""},
        { Command.name, nana,"","" },
        { text, "何を言ってるの…？","",""},
        { Command.name, mari,"","" },
        { text, "最近こういう夢をよく見るんだ。\n暗い夜の夢","",""},
        { Command.name, nana,"","" },
        { text, "ここは夢じゃないよ。暗くて、寂しくて、","",""},
        { text, "\"あいつら\"が巣くう場所なんだ","",""},
        { Command.name, mari,"","" },
        { text, "あなたは何か知ってるの？","",""},
        { Command.name, nana,"","" },
        { text, "ううん。ただ、そういう場所だってことは知ってる…\nでも、私が何でこんなところにいるのかも、誰だったのかも覚えてないの……","",""},
        { Command.name, mari,"","" },
        { text, "元々は人間だったの？","",""},
        { Command.name, nana,"","" },
        { text, "そのはず…","",""},
        { text, "","",""},
        { text, "っ！","",""},
        { Command.name, mari,"","" },
        { text, "どうしたの？","",""},
        { Command.name, nana,"","" },
        { text, "近くにいる…\nきっと\"あいつら\"だ…","",""},
        { text, "ここを離れよう！","",""},
    };

    public string[,] Sentence3 =
    {
        { start, "", "", "" },
        { act, "FirstItem", "", "" },
        { Command.name, mari,"","" },
        { text, "なんだろう…これ","",""},
        { Command.name, nana,"","" },
        { text, "お札…かな？","",""},
        { Command.name, mari,"","" },
        { text, "初めて見た、お札","",""},
        { Command.name, nana,"","" },
        { text, "なんでこんな所にあるんだろう…","",""},
        { Command.name, mari,"","" },
        { text, "とりあえず持っていこうか","",""},
    };
}
