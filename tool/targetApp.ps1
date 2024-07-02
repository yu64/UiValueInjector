#　アセンブリの読み込み
[void][System.Reflection.Assembly]::Load("Microsoft.VisualBasic, Version=8.0.0.0, Culture=Neutral, PublicKeyToken=b03f5f7f11d50a3a")

#　インプットボックスの表示
$input = [Microsoft.VisualBasic.Interaction]::InputBox("Message", "Title")