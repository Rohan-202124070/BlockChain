using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockChain
{
    public class BlcokChain
    {
        public string _seleted_service { get; set; }
        public string _price { get; set; }
        public List<BlockData> _block_chain = new List<BlockData>();
        public Boolean _is_valid_chain { get; set; }
        public DateTime _time_stamp { get; set; }
        public int _index { get; set; }
    }
}
