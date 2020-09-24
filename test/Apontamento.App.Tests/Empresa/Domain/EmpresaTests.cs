using System;
using Xunit;
using FluentValidation.Results;
using System.Linq;

namespace Apontamento.App.Tests
{
    public class EmpresaTests
    {
        //private readonly App.Empresa.Domain.Empresa empresa;

        //public EmpresaTests()
        //{
        //    empresa = new App.Empresa.Domain.Empresa();
        //}

        //[Fact(DisplayName = "RetornaInvalidoPorId")]
        //public void QuandoIdNaoForPreenchidoRetornaFalso()
        //{
        //    //Arrange

        //    //Act
        //    var IdFoiPreenchido = empresa.IsValid();
            
        //    //Assert
        //    Assert.False(IdFoiPreenchido);
        //}


        //[Fact(DisplayName ="RetornaMensagemIdObrigatorio")]
        //public void QuandoIdNaoForPreenchidoRetornaMensagem()
        //{
        //    //Arrange
            
        //    //Act
        //    empresa.IsValid();
        //    var erros = empresa.ValidationResult.Errors.Select(erro => erro.ErrorMessage).ToList();
            
        //    //Assert
        //    Assert.Contains("O Id é obrigatório", erros);
        //}

        //[Fact(DisplayName = "RetornaInvalidoPorNome")]
        //public void QuandoNomeNaoForPreenchidoRetornaFalso()
        //{
        //    //Arrange

        //    //Act
        //    var NomeFoiPreenchido = empresa.IsValid();

        //    //Assert
        //    Assert.False(NomeFoiPreenchido);
        //}

        //[Fact(DisplayName = "RetornaMensagemNomeObrigatorio")]
        //public void QuandoNomeNaoForPreenchidoRetornaMensagem()
        //{
        //    //Arrange
        //    empresa.SetEmpresa(Guid.NewGuid(), string.Empty, false);

        //    //Act
        //    empresa.IsValid();
        //    var erros = empresa.ValidationResult.Errors.Select(erro => erro.ErrorMessage).ToList();

        //    //Assert
        //    Assert.Contains("Nome é obrigatório", erros);
        //}

        //[Fact(DisplayName = "RetornaMensagemNomeMaximoPermitio")]
        //public void QuandoNomeForMaior150CaracteresRetornaMensagem()
        //{
        //    //Arrange
        //    string nome = "abcdefghijklmnopqrstuvxz abcdefghijklmnopqrstuvxz abcdefghijklmnopqrstuvxz abcdefghijklmnopqrstuvxz abcdefghijklmnopqrstuvxz abcdefghijklmnopqrstuvxz";
        //    empresa.SetEmpresa(Guid.NewGuid(), nome, false);

        //    //Act
        //    empresa.IsValid();
        //    var erros = empresa.ValidationResult.Errors.Select(erro => erro.ErrorMessage).ToList();

        //    //Assert
        //    Assert.Contains("Nome permitido até 100 caracteres", erros);
        //}
    }
}
