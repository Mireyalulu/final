using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace final
{
   public class Registrosusuarios
    {
        string id;
        string nombre;
        string apellido;
        string correo;
        string tipousu;
        string contrasena;

        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        [JsonProperty(PropertyName = "nombre")]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        [JsonProperty(PropertyName = "apellido")]
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        [JsonProperty(PropertyName = "correo")]
        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }
        [JsonProperty(PropertyName = "tipousu")]
        public string Tipousu
        {
            get { return tipousu; }
            set { tipousu = value; }
        }
        [JsonProperty(PropertyName = "contrasena")]
        public string Contrasena
        {
            get { return contrasena; }
            set { contrasena = value; }
        }
    }
}
