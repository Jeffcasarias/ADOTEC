using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using WCF_ADOTEC.Interface;
using BLL_ADOTEC.Login;
using BLL_ADOTEC.Reportes;
using BLL_ADOTEC.Test;
using BLL_ADOTEC.CatMant;
using DAL_ADOTEC.CatMant;
using DAL_ADOTEC.ConexionBD;
using System.Data;

namespace WCF_ADOTEC.Contract
{
    public class Service_ADOTEC :  IService_ADOTEC
    {
        public string Metodo_Prueba(string value)
        {
            return string.Format("Prueba de configuracion: {0}", value);
        }
        public DataTable Validar_Usuario(string Usuario, string Contrasena)
        {
            
            cls_Login_BLL Obj_Login = new cls_Login_BLL();            
                        
            return Obj_Login.ValidarUsuario(Usuario, Contrasena);            

        }

        public string Recuperar_Contrasena(string Correo)
        {
            cls_Login_BLL Obj_Recuperar = new cls_Login_BLL();

            return Obj_Recuperar.RecuperarContrasena(Correo);
        }

        public void RespuestasTest(string [] Respuestas)
        {
            cls_TestAptitud_BLL objBLL = new cls_TestAptitud_BLL();

            objBLL.VerificaAptitud(Respuestas);

        }

        public DataTable Filtrar_Estudiante(int iIdEstudiante)
        {
            cls_TestAptitud_BLL objBLL = new cls_TestAptitud_BLL();

            return objBLL.Filtrar_Estudiante(iIdEstudiante);
        }

        public DataTable Genera_Reporte()
        {
            cls_Reportes_BLL obj_rep = new cls_Reportes_BLL();

            return obj_rep.GenerarExcel();
        }

        public void InsertarPersona(int IdPersona, string Nombre, string Ap1, string Ap2, DateTime FechaNacimiento, char Rol)
        {
            cls_Persona_BLL objPersonaBLL = new cls_Persona_BLL();
            cls_Persona_DAL objPersonaDAL = new cls_Persona_DAL();
            cls_Usuario_DAL objUsuarioDAL = new cls_Usuario_DAL();

            objPersonaDAL.iIDPERSONA = IdPersona;
            objPersonaDAL.sNOMBRE = Nombre;
            objPersonaDAL.sAPELLIDO1 = Ap1;
            objPersonaDAL.sAPELLIDO2 = Ap2;
            objPersonaDAL.dFECHA_NAC = FechaNacimiento;
            objPersonaDAL.cIDESTADO = 'A';

            objUsuarioDAL.cIDESTADO = 'A';
            objUsuarioDAL.cIDROL = Rol;

            objPersonaBLL.InsertarPersona(ref objPersonaDAL, ref objUsuarioDAL);
            
        }
    }
}
