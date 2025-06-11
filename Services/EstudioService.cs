using ApiLocadora.DataContexts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiLocadora.Services
{
    public class EstudioService
    {
        private readonly AppDbContext _context;

        private readonly IMapper _mapper;

        public EstudioService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool Exist(int id)
        {
            return _context.Estudios.Where(c => c.Id == id).Any();
        }
    }
}
