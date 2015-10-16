
## プロジェクトの準備

---
#### マスターバージョンのリポジトリを `Fork` する

[`tom10987/Kotodama`](https://github.com/tom10987/Kotodama)

上記のリンク先に移動、ページ右上にある `Fork` ボタンをクリックするだけです。  
ボタンの横にある数字は、リポジトリを `Fork` しているユーザー数です。

---
## `git` の設定手順




---
## `GitHub` 上のリポジトリを自分の PC に持ってくる

---
#### `clone` を使う方法

ターミナル（`cygwin`）を起動、`cd` コマンドを使って、目的の場所に移動してください。  
仮に、デスクトップに `clone` するものとして進めます。

`XXXX` には、PC のユーザー名を入力します。

~~~
cd /cygdrive/c/Users/XXXX/Desktop/
~~~

以下のコマンドを入力して `GitHub` のリポジトリをコピーします。  
`XXXX` の部分には、**`GitHub` 上のアカウント名** を入力してください。

~~~
git clone https://github.com/XXXX/Kotodama.git
~~~

目的の場所（この例ではデスクトップ）にフォルダが作られていれば完了です。

---
#### `remote` を使う方法

ターミナル（`cygwin`）を起動、`cd` コマンドを使って、コピーする場所に移動します。  
仮に、デスクトップにコピーするものとして進めます。

`XXXX` には、PC のユーザー名を入力します。  
**先にフォルダを作っておく必要があることに注意**

~~~
cd /cygdrive/c/Users/XXXX/Desktop/Kotodama/
~~~

`git` コマンドを使えるように、初期化します。

~~~
git init
~~~

連携させたい `GitHub` 上のリポジトリを設定します。  
`XXXX` の部分には、**`GitHub` 上のアカウント名** を入力してください。

~~~
git remote add origin https://github.com/XXXX/Kotodama.git
~~~

以下のコマンドを入力して `GitHub` 上のリポジトリをコピーします。

~~~
git pull origin
~~~

目的の場所（この例ではデスクトップ）にフォルダが作られていれば完了です。

---
