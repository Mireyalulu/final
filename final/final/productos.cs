using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace final
{
   public class productos
    {
        string id;
        string nombre;
        string descripcion;
        string precio;
        string imagen;

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
        [JsonProperty(PropertyName = "descripcion")]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        [JsonProperty(PropertyName = "precio")]
        public string Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        [JsonProperty(PropertyName = "imagen")]
        public string Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }
    }
}
