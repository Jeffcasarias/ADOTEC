using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_ADOTEC.Test;
using DAL_ADOTEC.ConexionBD;

namespace BLL_ADOTEC.Test
{
    public class cls_TestAptitud_BLL
    {
        cls_TestAptitud_DAL objDAL = new cls_TestAptitud_DAL();
        cls_ConexBD_DAL objCnx = new cls_ConexBD_DAL();

        public void VerificaAptitud (string [] Respuestas, ref cls_VariablesConexBD_DAL objVariablesCnx)
        {
            objDAL.iCTPA_01 = 0;
            objDAL.iCTPA_02 = 0;
            objDAL.iCTPA_03 = 0;
            objDAL.iCTPA_04 = 0;
            objDAL.iCTPA_05 = 0;
            Respuestas[0] = "12345678";
            /* if(Respuestas[1] != null)
             {*/

            objDAL.iIdPersona = Convert.ToInt32(Respuestas[0]);
            
            for (int i = 0; i < Respuestas.Length; i++)
            {
                if (Respuestas[i] == "Si")
                {
                    if (i == 2 || i == 5 || i == 16 || i == 22 || i == 30)
                    {
                        objDAL.iCTPA_01++;
                    }
                    else if (i == 6 || i == 11 || i == 18 || i == 24 || i == 28)
                    {
                        objDAL.iCTPA_02++;
                    }
                    else if (i == 3 || i == 13 || i == 26 || i == 29 || i == 34)
                    {
                        objDAL.iCTPA_03++;
                    }
                    else if (i == 4 || i == 10 || i == 17 || i == 23 || i == 27)
                    {
                        objDAL.iCTPA_04++;
                    }
                    else if (i == 1 || i == 7 || i == 15 || i == 21 || i == 32)
                    {
                        objDAL.iCTPA_05++;
                    }
                }
            }

            InsertarAptitud(ref objVariablesCnx);

            //}
        }
        public string InsertarAptitud(ref cls_VariablesConexBD_DAL objVariablesCnx)
        {
            objCnx.CrearParametros(ref objVariablesCnx);
            objVariablesCnx.DT_Parametros.Rows.Add("@IDPERSONA", 2, objDAL.iIdPersona);
            objVariablesCnx.DT_Parametros.Rows.Add("@CTPA_01", 5, objDAL.iCTPA_01);
            objVariablesCnx.DT_Parametros.Rows.Add("@CTPA_02", 5, objDAL.iCTPA_02);
            objVariablesCnx.DT_Parametros.Rows.Add("@CTPA_03", 5, objDAL.iCTPA_03);
            objVariablesCnx.DT_Parametros.Rows.Add("@CTPA_04", 5, objDAL.iCTPA_04);
            objVariablesCnx.DT_Parametros.Rows.Add("@CTPA_05", 5, objDAL.iCTPA_05);

            objVariablesCnx.sSP_Name = "dbo.SP_INSERTAR_EAPTITUD";
            objCnx.Ejec_Scalar(ref objVariablesCnx);

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
