namespace Locations.Models
{
    public class SearchAddress
    {
        public string CEP { get; set; }
        public string CHAVE { get; set; } 
        public string UF { get; set; }
        public string Tipo_Oficial { get; set; }
        public string Tipo_Acento { get; set; }
        public string Nome_Oficial { get; set; }
        public string Nome_Acento { get; set; }
        public string Bairro1_Oficial { get; set; }
        public string Bairro1_Acento { get;  set; }
        public string Cidade_Oficial { get; set; }
        public string Cidade_Acento { get; set; }
        public string Cod_Mun { get; set; }
        public string LIMINFPAR { get; set; }
        public string LIMINFIMPA { get; set; }
        public string LIMSUPPAR { get; set; }
        public string LIMSUPIMPA { get; set; }
        public string FLAGS { get; set; }
        public string LADOS { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string log_complemento { get; set; }
        public string nome_cep_esp { get; set; }
        public string DDD { get; set; }
    }
}
