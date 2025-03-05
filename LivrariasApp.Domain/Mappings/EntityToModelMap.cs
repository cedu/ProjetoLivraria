using AutoMapper;
using LivrariasApp.Domain.Model;
using ProjetoLivraria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariasApp.Domain.Mappings
{
    public class EntityToModelMap : Profile
    {
        public EntityToModelMap()
        {
            //Usuario => UsuarioModel
            CreateMap<Usuario, UsuarioModel>();
        }
    }
}
