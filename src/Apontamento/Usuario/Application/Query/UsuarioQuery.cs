﻿using System;

namespace Apontamento.Usuario.Application.Query
{
    public class UsuarioQuery
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public string Token { get; set; }

    }
}
