
### 開発環境のバージョンについて

- `Microsoft Visual Studio Community 2015`  
- `Unity 5.2.1f1`  
- `Android SDK Tools 24.4`  
- `Android 6.0 (API 23)`  
- `Google USB Driver 11`  
- `Java SE Development Kit 8u60`  
- `DeployGate`

`Unity 5.2.1f1` のインストール時に `Visual Studio Tools for Unity 2015` が  
オプションで選択可能になっているはずなので、必ず選択してからインストールしてください。

`Android` に関する情報は、後述する `SDK Manager` から確認できます。

`Java` は、インストール時に必ず確認してください。

`DeplayGate` は **`Android` 実機**にインストールするアプリです。  
`Google Play` からインストールしておいてください。

今後、何らかの問題が発生しない限り、この開発環境で進めていきます。  
勝手に更新しない、されないように気をつけてください。

---
### Android 向けビルド環境の準備

`Unity` で `Android` 向けビルドをできるようにするには、下記２点が必須となります。  
- **`Java SE Development Kit`**
- **`Android SDK`**

**インストールは、必ず `Java` から始めてください。**  
`Android SDK` が `Java` に依存しているため、インストール時に `Java` のフォルダを検索するためです。

---
#### `Java SE Development Kit`

[**こちらのページ**][Link_JDK]に移動、リンク先の `JDK` のダウンロードボタンをクリックしてください。

プラットフォームごとのダウンロード一覧が表示されるので、  
`Java SE Development Kit ****` にある `Accept License Agreement` の項目にチェックを入れてから、  
`Windows x64` の項目にあるダウンロードリンクよりファイルをダウンロードしてください。

~~~
**** は、バージョン番号が表示されます。  
8u60 であれば、問題ありません。
~~~

ダウンロードしたファイルを実行、インストールが完了したら `Finish` をクリックして大丈夫です。  
**インストール先のフォルダの場所はメモするなど、必ず覚えておいてください。**

---
#### `Android SDK`

[**こちらのページ**][Link_AndroidSDK]に移動、リンク先の **他のダウンロードオプション** をクリックしてください。

`SDK Tools Only` の `Windows` の項目から、`.exe` 形式のファイルをダウンロードしてください。  
実行すると、`SDK Manager` のインストールが開始されます。  
**保存先のフォルダをメモに残すなど、必ず覚えておいてください。**

保存先のフォルダを開き、`SDK Manager.exe` を **右クリックして、「管理者として実行」** を選択してください。

すでにいくつかの項目にチェックが入っているはずなので、  
そのまま画面右下のほうにある `Install` をクリックしてインストール開始です。  
完了後、最初の画面でチェックの入っていた項目が全て `Installed` に変わっていたら大丈夫です。

---
#### `Unity Editor` 側の設定

~~~
それぞれ、確認して問題がなければ、変更しなくて大丈夫です。
~~~

- `SDK`、`JDK` の設定

`Edit -> Preferences... -> External Tools` の順にクリック、`Android` の項目にある  
`SDK`、`JDK` にそれぞれのフォルダを指定します。

`Browse` ボタンをクリックすれば、自動的にフォルダの位置を開くはずなので、  
そのまま **「フォルダーの選択」** をクリックしてください。

全く違う場所を開いた、または **すでに入力済みだが違うフォルダ** だった時など、  
`SDK`、`JDK` のフォルダを自動的に開かなかった場合は、  
上記インストール手順で自分が指定したフォルダの場所を設定してください。

**違うフォルダを選択しようとすると、警告が出て選択できません。**  
何も警告が出なければ成功です。

- `Android` 向けのビルド設定にする

`File -> Build Settings...` の順にクリック、  
開いたウィンドウの `Platform` 欄で、`Android` を選択、`Switch Platform` ボタンをクリックすれば完了です。

---
#### 実機のテスト方法

`Google Play` で `DeployGate` を検索、アプリをインストールしてください。  
アプリ側からアカウント作成ができます。`GitHub` アカウントに紐づけも可能です。

アカウント登録後、PC で[**こちらのページ**][Link_DeployGate]にログインし、ビルドしたアプリをアップロードすると、  
アプリのダウンロードができる QR コードが生成されます。

`Android` 実機にインストールした `DeployGate` を起動、アプリ側で QR コードを読み取ると、  
ダウンロードが開始されます。

ダウンロード完了後は、`DeployGate` を経由して制作したアプリのテストができます。

---
#### 参考リンク

- [DeployGate][Link_DeployGate]
- [Java SE Downloads][Link_JDK]  
- [Android SDK][Link_AndroidSDK]

---

[Link_DeployGate]: https://deploygate.com
[Link_JDK]: http://www.oracle.com/technetwork/java/javase/downloads/index.html
[Link_AndroidSDK]: http://developer.android.com/intl/ja/sdk/index.html

