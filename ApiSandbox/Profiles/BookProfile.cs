using ApiSandbox.DTOs;
using ApiSandbox.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSandbox.Profiles
{
    public class BookProfile :Profile
    {
        public BookProfile()
        {
            CreateMap<CreateBookDto, Book>();

            //here you have to insert another map
        }
    }
}
