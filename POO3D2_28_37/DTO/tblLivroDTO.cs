using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POO3D2_28_37.DTO
{
    public class tblLivroDTO
    {
        private int id_Livro, id_Autor, id_Editora;
        private string titulo, num_Paginas;
        private DateTime dataCadastro;
        private double valor;
        public int Id_Livro { get => id_Livro; set => id_Livro = value; }

        public int Id_Autor
        {
            set
            {
                this.id_Autor = value;
            }
            get { return this.id_Autor; }
        }
        public int Id_Editora
        {
            set
            {

                this.Id_Editora = value;
            }

            get { return this.id_Editora; }
        }

        public string Titulo
        {
            set
            {
                if (value != string.Empty)
                {
                    this.titulo = value;
                }
                else
                {
                    throw new Exception("O campo 'Titulo' é obrigatório!");
                }
            }
            get { return this.titulo; }
        }

        public string NumeroPaginas
        {
            set
            {
                if (value != string.Empty)
                {
                    this.num_Paginas = value;
                }
                else
                {
                    throw new Exception("O campo 'Número Paginas' é obrigatório!");
                }
            }
            get { return this.num_Paginas; }
        }

        public DateTime DataCadastro { get => dataCadastro; set => dataCadastro = value; }
        public double Valor { get => valor; set => valor = value; }
    }
}