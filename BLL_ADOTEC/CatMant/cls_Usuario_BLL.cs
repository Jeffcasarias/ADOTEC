using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_ADOTEC.ConexionBD;
using DAL_ADOTEC.CatMant;

namespace BLL_ADOTEC.CatMant
{
    public class cls_Usuario_BLL
    {
        cls_ConexBD_DAL objCnx = new cls_ConexBD_DAL();

        public string InsertarUsuario(cls_Usuario_DAL objUsuario)
        {
            cls_VariablesConexBD_DAL objVariablesCnx = new cls_VariablesConexBD_DAL();
            objCnx.CrearParametros(ref objVariablesCnx);
            objVariablesCnx.DT_Parametros.Rows.Add("@IDUSUARIO", 2, objUsuario.iIDPERSONA);
            objVariablesCnx.DT_Parametros.Rows.Add("@IDPERSONA", 2, objUsuario.iIDPERSONA);
            objVariablesCnx.DT_Parametros.Rows.Add("@CONTRASENA", 3, objUsuario.sCONTRASENA.Trim());
            objVariablesCnx.DT_Parametros.Rows.Add("@IDROL", 6, objUsuario.cIDROL);
            objVariablesCnx.DT_Parametros.Rows.Add("@IDESTADO", 6, objUsuario.cIDESTADO);
            /*objVariablesCnx.DT_Parametros.Rows.Add("@CTPA_06", 5, objDAL.iCTPA_06);
            objVariablesCnx.DT_Parametros.Rows.Add("@CTPA_07", 5, objDAL.iCTPA_07);*/

            objVariablesCnx.sSP_Name = "dbo.SP_INSERTAR_USUARIOS";
            objCnx.Execute_NonQuery(ref objVariablesCnx);

            if (objVariablesCnx.sMsjError == string.Empty)
            {
                return null;
            }
            else
            {
                return objVariablesCnx.sMsjError;
            }
        }
    }
}
