using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDMVC_PROJECT.Models;
using CRUDMVC_PROJECT.Data;

namespace CRUDMVC_PROJECT.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly ContatoContext contato_Context;
        public ContatoRepository(ContatoContext contatoContext)
        {
            contato_Context = contatoContext;
        }
        public ContatoModel adicionar (ContatoModel contato)
        {
            contato_Context.Contato.Add(contato);
            contato_Context.SaveChanges();
            return contato;
        }

        public ContatoModel atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = buscarId(contato.Id);

            if(contatoDB == null) throw new Exception("Houve um erro:");

            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Telefone = contato.Telefone;

            contato_Context.Contato.Update(contatoDB);
            contato_Context.SaveChanges();
            return contatoDB;

        }

        public ContatoModel buscarId(int id)
        {
            return contato_Context.Contato.FirstOrDefault(x => x.Id == id);
        }

        public bool deletar(int id)
        {
            ContatoModel contatoDB = buscarId(id);
            contato_Context.Contato.Remove(contatoDB);
            contato_Context.SaveChanges();
            return true;
        }

        public List<ContatoModel> listarContatos()
        {
            return contato_Context.Contato.ToList();
        }
    }
}