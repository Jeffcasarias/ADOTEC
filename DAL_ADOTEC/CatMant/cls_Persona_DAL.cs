using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ADOTEC.CatMant
{
    public class cls_Persona_DAL
    {
		int _iIDPERSONA;
		string _sNOMBRE, _sAPELLIDO1, _sAPELLIDO2;
		DateTime _dFECHA_NAC;
		char _cIDESTADO;

        public int iIDPERSONA { get => _iIDPERSONA; set => _iIDPERSONA = value; }
        public string sNOMBRE { get => _sNOMBRE; set => _sNOMBRE = value; }
        public string sAPELLIDO1 { get => _sAPELLIDO1; set => _sAPELLIDO1 = value; }
        public string sAPELLIDO2 { get => _sAPELLIDO2; set => _sAPELLIDO2 = value; }
        public DateTime dFECHA_NAC { get => _dFECHA_NAC; set => _dFECHA_NAC = value; }
        public char cIDESTADO { get => _cIDESTADO; set => _cIDESTADO = value; }
    }
}
