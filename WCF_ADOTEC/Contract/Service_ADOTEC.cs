using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using WCF_ADOTEC.Interface;
using BLL_ADOTEC.Login;

namespace WCF_ADOTEC.Contract
{
    public class Service_ADOTEC :  IService_ADOTEC
    {
        public string Metodo_Prueba(string value)
        {
            return string.Format("Prueba de configuracion: {0}", value);
        }
        public string Validar_Usuario(string Usuario, string Contrasena)
        {
            string Confirmacion;
            cls_Login_BLL Obj_Login = new cls_Login_BLL();
            Confirmacion = Obj_Login.ValidarUsuario(Usuario, Contrasena);
                        
             return Confirmacion;            

        }

        public string Recuperar_Contrasena(string Correo)
        {
            cls_Login_BLL Obj_Recuperar = new cls_Login_BLL();

            return Obj_Recuperar.RecuperarContrasena(Correo);
        }
    }
}
