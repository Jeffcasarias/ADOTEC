using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_ADOTEC.Test;
using DAL_ADOTEC.ConexionBD;
using System.Data;

namespace BLL_ADOTEC.Reportes
{
    public class cls_Reportes_BLL
    {
        cls_ConexBD_DAL objCnx = new cls_ConexBD_DAL();
        cls_VariablesConexBD_DAL objVar = new cls_VariablesConexBD_DAL();

        public DataTable GenerarExcel()
        {
            objVar.sTableName = "Reporte";
            objVar.sSP_Name = "dbo.SP_GENERA_REPORTE";
            objCnx.Execute_DataAdapter(ref objVar);

            if (objVar.sMsjError == string.Empty)
            {
                return objVar.Obj_DSet.Tables[0];
            }
            else
            {

                return null;
            }
        }

    }
}
