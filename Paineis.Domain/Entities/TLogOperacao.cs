﻿namespace Paineis.Domain.Entities
{
    public partial class TLogOperacao
    {
        public DateTime DataLogOperacao { get; set; }
        public string MatriculaUsuarioLogOperacao { get; set; }
        public int CodigoPerfilLogOperacao { get; set; }
        public int CodigoFuncaoLogOperacao { get; set; }
        public string DescricaoLogOperacao { get; set; }
        public string TipoQueryLogOperacao { get; set; }
    }
}
