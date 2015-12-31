using UnityEngine;

public class Test : MonoBehaviour {

    /// <summary>
    /// このスクリプトがついてるオブジェクトについている
    /// 「EventState.cs」を必ず読み込む！
    /// </summary>
    EventState state;

    void Start()
    {
        state = this.gameObject.GetComponentInChildren<EventState>();
        state._entry = test;
    }

    public string[,] test =
    {
        { Command.start, "", "", "" },
        { Command.act,  "testChapter", "", "" },
        { Command.name, CharaName.narrator, "", "" },
        { Command.text, "チャプターテスト", "", "" },
        { Command.text, "これはテスト用のチャプターです", "", "" },
        { Command.text, "これからこのチャプターで使い方について説明していきますので", "", "" },
        { Command.text, "Script->anko1210->Adventure->Storyの中の", "", "" },
        { Command.text, "「Test.cs」を開いてみてください", "", "" },
        { Command.text, "開いたら、クリックを押して選択肢を選んでください", "", "" },
        { Command.text, "テキスト→名前→画像→選択肢→始める方法→終わる方法→章登録方法の順で見ていくと", "", "" },
        { Command.text, "上から見ていくことができます", "", "" },
        { Command.text, "基本ルールは、第四引数まで。", "", "" },
        { Command.text, "入力する内容がなくても第四引数まで定義？だけします", "", "" },
        { Command.act,  "jump1", "", "" },
        { Command.text, "選択肢を選んでください", "", "" },
        { Command.jump, "テキスト表示について(explainText)", "名前表示について(explainName)", "次の選択肢(through)" },
        { Command.jump, "画像表示について(explainImage)", "選択肢について(explainJump)", "次の選択肢(through)" },
        { Command.jump, "始める方法(explainImage)", "終わる方法(explainEnd)", "次の選択肢(through)" },
        { Command.jump, "章登録方法(explainAct)", "最初の選択肢に戻る(jump1)", "" },
        ///
        { Command.act,  "explainText", "", "" },
        { Command.name, CharaName.narrator, "", "" },
        { Command.text, "これからテキストについて説明します", "", "" },
        { Command.text, "これはメッセージエリアに表示されるものを定義します", "", "" },
        { Command.text, "スクリプトの書き方については\n実際にソースを見てください", "", "" },
        { Command.text, "第一引数には「Command.text」を入力し", "", "" },
        { Command.text, "第二引数には実際に表示するテキストを入力します", "", "" },
        { Command.text, "表示できる文字数は全角50文字です", "", "" },
        { Command.text, "半角カタカナは表示されないので気を付けてね！", "", "" },
        { Command.text, "そこは改行コード（￥N）が使用できます", "", "" },
        { Command.text, "なので、\nこうやって改行できます", "", "" },
        { Command.text, "しかし三行目からは表示できないので改行しすぎに気を付けてください", "", "" },
        { Command.text, "第三引数、第四引数には何も書きません", "", "" },
        { Command.text, "説明は以上です", "", "" },
        { Command.jump, "次へ（名前）(explainName)", "選択肢まで戻る(jump1)", "終了(through)" },
        { Command.end, "", "", "" },
        ///
        { Command.act, "explainName", "", "" },
        { Command.name, CharaName.narrator, "", "" },
        { Command.text, "これから名前について説明します", "", "" },
        { Command.text, "名前エリアに表示されるものを設定します", "" , ""},
        { Command.text, "第一引数には「Command.name」を使用します", "", "" },
        { Command.text, "第二引数には表示する名前を入力していきます", "", "" },
        { Command.text, "その時、表示するものはクラス「CharaName」を使用すると簡単かつ間違えずにできます", "" , ""},
        { Command.text, "第三引数、第四引数には何も書きません", "" , ""},
        { Command.text, "では名前欄を「マリ」と表記させましょう", "", "" },
        { Command.name, CharaName.mari, "" , ""},
        { Command.text, "「……こんにちは」", "", "" },
        { Command.name, CharaName.narrator, "", "" },
        { Command.text, "ざっとこんな感じで変えることができます", "", "" },
        { Command.text, "説明は以上です", "", "" },
        { Command.jump, "次へ（画像）(explainImage)", "選択肢まで戻る(jump1)", "終了(through)" },
        { Command.end, "", "", "" },
        ///
        { Command.act, "explainImage", "", "" },
        { Command.name, CharaName.narrator, "", "" },
        { Command.text, "これから画像表示について説明します", "", "" },
        { Command.text, "画像表示するものを設定します", "", "" },
        { Command.text, "第一引数には「Command.image」と入力します", "", "" },
        /// { Command.image, },
        { Command.text, "第二引数には変更するキャラの名前を入力します", "", "" },
        { Command.text, "「charaName.mari」でマリちゃんを\n「CharaName.nana」でナナちゃんの画像を変更する準備をします", "", "" },
        /// { Command.image, CharaName.nana }　← ナナちゃん 
        /// { Command.image, CharaName.mari }　← マリちゃん
        { Command.text, "第三引数には表示する画像の名前を入力します", "", "" },
        { Command.text, "ここで「ImageName」と使用すると、登録された画像が使用できます", "", "" },
        /// { Command.image, CharaName.mari, ImageName.MARI_NORMAL }
        { Command.text, "第四引数にはポジションを入力します", "", "" },
        { Command.text, "「ImagePosition」と入力すると、ポジションの一覧（center, right. left）がででくるので", "", "" },
        { Command.text, "それらを使用してください", "", "" },
        /// { Command.image, CharaName.mari, ImageName.MARI_NORMAL, ImagePosition.center }
        { Command.text, "例えば...\n{ Command.image, CharaName.mari, ImageName.MARI_NORMAL, ImagePosition.center }", "", "" },
        { Command.text, "こう入力すると", "", "" },
        { Command.image, CharaName.mari, ImageName.MARI_NORMAL, ImagePosition.center},
        { Command.text, "真ん中にマリちゃんが表示されます", "", "" },
        { Command.text, "場所を変更する場合は", "", "" },
        { Command.image, CharaName.mari, ImageName.MARI_NORMAL, ImagePosition.left },
        { Command.text, "同じように書いて、ポジションを変更してあげてください", "", "" },
        { Command.text, "少し面倒ですが、今現在はとりあえずこれで動かしてください", "", "" },
        { Command.text, "説明は以上です", "", "" },
        { Command.jump, "次へ（選択肢）(explainJump)", "選択肢まで戻る(jump1)", "終了(through)" },
        { Command.end, "", "", "" },
        ///
        { Command.act, "explainJump", "", "" },
        { Command.name, CharaName.narrator, "" , ""},
        { Command.text, "これから選択肢について説明します", "" , ""},
        { Command.text, "第一引数には「Command.jump」を入力します", "", "" },
        { Command.text, "第二引数から第四引数に選択肢の内容を入力していきます", "", "" },
        { Command.text, "書き方について規定があります", "", "" },
        { Command.text, "「ボタンに表示する文字(act名)」です", "", "" },
        { Command.text, "ちょっとよくわかんない…と感じたら\n「Test.cs」内にある「public string[,] test」内の", "", "" },
        { Command.text, "16行か17行目をみてください", "", "" },
        { Command.text, "まあ書類に使い方纏めます", "", "" },
        { Command.text, "説明は以上です", "", "" },
        { Command.jump, "次へ（終わり）(explainEnd)", "選択肢まで戻る(jump1)", "終了(through)" },
        { Command.end, "", "", "" },
        ///
        { Command.act, "explainEnd", "", "" },
        { Command.name, CharaName.narrator, "", "" },
        { Command.text, "終わりについて説明", "", "" },
        { Command.text, "第一引数に「Command.end」を入力します", "", "" },
        { Command.text, "そうすると勝手にキャンバスが消されます", "", "" },
        { Command.text, "お話が終了するときに使用します", "", "" },
        { Command.text, "説明は以上です", "", "" },
        { Command.jump, "次へ（始まり）(explainStart)", "選択肢まで戻る(jump1)", "終了(through)" },
        { Command.end, "", "", "" },
        ///
        { Command.act, "explainStart", "", "" },
        { Command.name, CharaName.narrator, "", "" },
        { Command.text, "始まり（初期化）について説明", "", "" },
        { Command.text, "第一引数に「Command.start」と入力します", "", "" },
        { Command.text, "するとキャンバスの表示物をすべて空っぽにしてくれます", "", "" },
        { Command.text, "初期化されるものは…", "", "" },
        { Command.text, "名前表示エリア", "", "" },
        { Command.text, "メッセージ表示エリア", "", "" },
        { Command.text, "画像表示エリア\n（非表示にします）", "", "" },
        { Command.text, "以上三つです", "", "" },
        { Command.text, "なので、お話し途中で初期化したい場合は", "", "" },
        { Command.text, "このコマンドを書いてあげてください", "", "" },
        { Command.text, "説明は以上です", "", "" },
        { Command.jump, "次へ（章登録）(explainAct)", "選択肢まで戻る(jump1)", "終了(through)" },
        { Command.end, "", "", "" },
        ///
        { Command.act, "explainAct", "", "" },
        { Command.name, CharaName.narrator, "", "" },
        { Command.text, "章登録について説明", "", "" },
        { Command.text, "これは選択肢を関連して使用します", "", "" },
        { Command.text, "説明については長くなるので別書類で説明します", "", "" },
        { Command.text, "以上です", "", "" },
        { Command.jump, "選択肢まで戻る(jump1)", "終了(through)", "" },
        { Command.end, "", "", "" },
    };


}
