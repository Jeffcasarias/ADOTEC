using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ADOTEC.CatMant
{
    public class cls_Usuario_DAL
    {
        int _iIDUSUARIO, _iIDPERSONA;
        string _sCONTRASENA;
        char _cIDROL, _cIDESTADO;

        public int iIDUSUARIO { get => _iIDUSUARIO; set => _iIDUSUARIO = value; }
        public int iIDPERSONA { get => _iIDPERSONA; set => _iIDPERSONA = value; }
        public string sCONTRASENA { get => _sCONTRASENA; set => _sCONTRASENA = value; }
        public char cIDROL { get => _cIDROL; set => _cIDROL = value; }
        public char cIDESTADO { get => _cIDESTADO; set => _cIDESTADO = value; }
    }
}
