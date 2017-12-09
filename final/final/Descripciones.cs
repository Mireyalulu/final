using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.MobileServices;

namespace final
{
    public class Descripciones
    {
        string id;
        string descripcion;

        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        [JsonProperty(PropertyName = "descripcion")]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        [Version]
        public string Version { get; set; }

    }
}