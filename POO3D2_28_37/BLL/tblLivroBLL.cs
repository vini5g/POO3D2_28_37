using POO3D2_28_37.DAL;
using POO3D2_28_37.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace POO3D2_28_37.BLL
{
    public class tblLivroBLL
    {
        private tblLivroDAL daoBanco = new tblLivroDAL();

        public DataTable ListarLivros(string idLivro)
        {
            string sql = string.Format($@"select * from TBL_Livro where id = '{idLivro}';");
            return daoBanco.executarConsulta(sql);
        }

        public DataTable ListarLivros()
        {
            string sql = string.Format($@"select * from TBL_Livro");
            return daoBanco.executarConsulta(sql);
        }

        public void InserirLivro(tblLivroDTO dtolivro)
        {
            string sql = string.Format($@"INSERT INTO TBL_Livro VALUES (NULL,'{dtolivro.Id_Autor}',
                                                                               '{dtolivro.Id_Editora}',   
                                                                               '{dtolivro.Titulo}',
                                                                              '{dtolivro.DataCadastro.ToString("yy-MM-dd")}',
                                                                               '{dtolivro.NumeroPaginas}',
                                                                               '{dtolivro.Valor}');");
            daoBanco.executarComando(sql);
        }

        public void AlterarLivro(tblLivroDTO dtoLivros)
        {
            string sql = string.Format($@"UPDATE TBL_Livro set   idAutor = '{dtoLivros.Id_Autor}',
                                                                 idEditora = '{dtoLivros.Id_Editora}',
                                                                 titulo = '{dtoLivros.Titulo}',
                                                                 numPaginas = '{dtoLivros.NumeroPaginas}',
                                                                 valor = '{dtoLivros.Valor}'
                                                where idLivro = '{dtoLivros.Id_Livro}';");
            daoBanco.executarComando(sql);

        }

        public void ExcluirLivro(tblLivroDTO dtolivraria)
        {
            string sql = string.Format($@"DELETE FROM TBL_Livro where idLivro = {dtolivraria.Id_Livro};");
            daoBanco.executarComando(sql);

        }
    }
}