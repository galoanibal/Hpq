namespace PRUEBA.QPH.WEB.Models {
    public class ErrorViewModel {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);


        public string Titile { get; set; }

        public string ExceptionMessage { get; set; }

        public string DescriptionDetail { get; set; }
    }
}
