using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockChain
{
    public class TextBoxData
    {
        TextBox name;
        TextBox contribution;
        Button button;

        public TextBox Name { get => name; set => name = value; }
        public TextBox Contribution { get => contribution; set => contribution = value; }
        public Button Button { get => button; set => button = value; }
    }
}
