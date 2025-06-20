﻿using ApiLocadora.Common.Exceptions;
using ApiLocadora.DataContexts;
using ApiLocadora.Dtos;
using ApiLocadora.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Windows.Markup;

namespace ApiLocadora.Services
{
    public class FilmeService
    {
        private readonly AppDbContext _context;

        private readonly IMapper _mapper;

        public FilmeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<Filme>> GetAll()
        {
            var list = await _context.Filmes.Include(e => e.Estudio).ToListAsync();

            return list;
        }

        public async Task<Filme?> GetOneById(int id)
        {
            try
            {
                return await _context.Filmes
                    .SingleOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Filme?> Create(FilmeDto filme)
        {
            try
            {
                var newFilme = _mapper.Map<Filme>(filme);

                await _context.Filmes.AddAsync(newFilme);
                await _context.SaveChangesAsync();

                return newFilme;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public async Task<Filme?> Update(int id, FilmeDto filme)
        {
            try
            {
                var _filme = await GetOneById(id);

                if (_filme is null)
                {
                    return _filme;
                }

                _filme.Nome = filme.Nome;
                _filme.Genero = filme.Genero;

                _context.Filmes.Update(_filme);
                await _context.SaveChangesAsync();

                return _filme;
            }
            catch (Exception ex)
            {
                    throw ex;
            }
            
        }

        public async Task<Filme?> Delete(int id)
        {
            return null;
        }

        private async Task<bool> Exist(int id)
        {
            return await _context.Filmes.AnyAsync(c => c.Id == id);
        }
    }
}
