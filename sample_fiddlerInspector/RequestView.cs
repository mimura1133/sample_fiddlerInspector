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
    /// リクエストビュー
    /// ビューに関する基本的な処理は全て View.cs 内で処理する（必要に応じて Override すればよい）
    /// </summary>
    public class RequestView : View, IRequestInspector2
    {
        public HTTPRequestHeaders headers { get; set; }
    }
}
