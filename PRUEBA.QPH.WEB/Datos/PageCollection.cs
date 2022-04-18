using System.Collections.Generic;

namespace PRUEBA.QPH.WEB.Datos {
    public class PageCollection{
        public IList<dynamic> Data { get; set; }
        public int TotalRegistros { get; set; }
        public int TotalPaginas { get; set; }
    }
}
