using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_ADOTEC.ConexionBD;
using DAL_ADOTEC.CatMant;
using BLL_ADOTEC.CatMant;


namespace BLL_ADOTEC.CatMant
{
    public class cls_Persona_BLL
    {
        cls_ConexBD_DAL objCnx = new cls_ConexBD_DAL();

        public string InsertarPersona(ref cls_Persona_DAL objPersona, ref cls_Usuario_DAL objUsuario)
        {
            cls_Usuario_BLL objUsuarioBLL = new cls_Usuario_BLL();
            cls_VariablesConexBD_DAL objVariablesCnx = new cls_VariablesConexBD_DAL();
            objCnx.CrearParametros(ref objVariablesCnx);
            objVariablesCnx.DT_Parametros.Rows.Add("@IDPERSONA", 2, objPersona.iIDPERSONA);
            objVariablesCnx.DT_Parametros.Rows.Add("@NOMBRE", 3, objPersona.sNOMBRE);
            objVariablesCnx.DT_Parametros.Rows.Add("@APELLIDO1", 3, objPersona.sAPELLIDO1);
            objVariablesCnx.DT_Parametros.Rows.Add("@APELLIDO2", 3, objPersona.sAPELLIDO2);
            objVariablesCnx.DT_Parametros.Rows.Add("@FECHA_NAC", 7, objPersona.dFECHA_NAC);
            objVariablesCnx.DT_Parametros.Rows.Add("@IDESTADO", 6, objPersona.cIDESTADO);
            /*objVariablesCnx.DT_Parametros.Rows.Add("@CTPA_06", 5, objDAL.iCTPA_06);
            objVariablesCnx.DT_Parametros.Rows.Add("@CTPA_07", 5, objDAL.iCTPA_07);*/

            objVariablesCnx.sSP_Name = "dbo.SP_INSERTAR_PERSONA";
            objCnx.Execute_NonQuery(ref objVariablesCnx);

            if (objVariablesCnx.sMsjError == string.Empty)
            {
                objUsuario.iIDUSUARIO = objPersona.iIDPERSONA;
                objUsuario.iIDPERSONA = objPersona.iIDPERSONA;
                objUsuario.sCONTRASENA = objPersona.dFECHA_NAC.ToString("ddMMyyyy");


                objUsuarioBLL.InsertarUsuario(objUsuario);

                return null;
            }
            else
            {
                return objVariablesCnx.sMsjError;
            }
        }
    }
}
