using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fiddler;

[assembly: Fiddler.RequiredVersion("2.3.0.0")]

namespace sample_fiddlerInspector
{
    /// <summary>
    /// ビューの共通処理（リクエスト・レスポンス共に共通する処理が多いため）
    /// </summary>
    public class View : Inspector2
    {
        private TextBox _textBox;

        /// <summary>
        /// Inspector ビューへの項目の追加やウィンドウの初期化等を行う
        /// </summary>
        /// <param name="o"></param>
        public override void AddToTab(TabPage o)
        {
            _textBox = new TextBox() {Dock = DockStyle.Fill, Multiline = true};

            o.Text = "Sample Inspector";
            o.Controls.Add(_textBox);
        }

        /// <summary>
        /// 項目が必要なくなった場合のクリーンアップ処理を書く (IDisposable の Dispose みたいな）
        /// </summary>
        public void Clear()
        {

        }

        /// <summary>
        /// メッセージ本文 (BODY)
        ///
        /// ここには、表示部とデータの受け渡しおよび変換処理を記述します。
        /// 
        /// このサンプルは、何も考慮せずに UTF-8 のテキストデータとして処理する例です。
        /// もし MessagePack や JSON などを処理する場合はここで記述します。
        /// 
        /// </summary>
        public byte[] body
        {
            get => Encoding.UTF8.GetBytes(_textBox.Text);
            set =>  _textBox.Text = value != null ? Encoding.UTF8.GetString(value) : "";
        }

        /*
         * 可読性のためにラムダ演算子 (=>) を使って記述していますが、
         * 下記のように書くことももちろん可能です。
         *
         *
         * public byte[] hoge
         * {
         *   get
         *   {
         *      return Encoding.UTF8.GetBytes(_textBox.Text);
         *   }
         *   set
         *   {
         *      _textBox.Text = Encoding.UTF8.GetString(value);
         *   }
         * }
         *
         */


        /// <summary>
        /// テキストが編集されたかどうかを返す
        ///
        /// 今回の例ではテキストボックスが編集されたかどうかを返します。
        /// </summary>
        public bool bDirty => _textBox.Modified;

        /// <summary>
        /// 読み取り専用項目かを取得・設定する
        ///
        /// 今回の例ではテキストボックスの読み取り専用のプロパティにそのまま割り当てます。
        /// </summary>
        public bool bReadOnly
        {
            get => _textBox.ReadOnly;
            set => _textBox.ReadOnly = value;
        }

        /// <summary>
        /// Inspector ビュー内の項目の順番（昇順でソートされるため、値が大きければ項目の最後に追加される）
        /// </summary>
        /// <returns>表示順番</returns>
        public override int GetOrder() => 1000;
    }
}
