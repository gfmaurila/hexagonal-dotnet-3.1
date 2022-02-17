namespace Domain.Dto
{
    public class RetornoApiDto<T> : RetornoApiDto
    {
        public T Retorno { get; set; }

        public int TotalRegistros { get; set; }
    }

    public class RetornoApiDto
    {
        public bool Sucesso { get; set; }

        public string Mensagem { get; set; }

        public int StatusCode { get; set; }
    }

    public class RetornoErroApiDto
    {
        public string ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        public string path { get; set; }
    }
}
