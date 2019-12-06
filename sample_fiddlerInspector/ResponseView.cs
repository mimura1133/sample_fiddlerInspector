using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fiddler;

namespace sample_fiddlerInspector
{
    /// <summary>
    /// レスポンスビュー
    /// ビューに関する基本的な処理は全て View.cs 内で処理する（必要に応じて Override すればよい）
    /// </summary>
    public class ResponseView : View, IResponseInspector2
    {
        public HTTPResponseHeaders headers { get; set; }
    }
}
