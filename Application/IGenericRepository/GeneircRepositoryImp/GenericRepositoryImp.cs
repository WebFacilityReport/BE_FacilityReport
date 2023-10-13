using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IGenericRepository.GeneircRepositoryImp
{
    public class GenericRepositoryImp<T> : IGenericRepository<T> where T : class
    {
        public readonly FacilityReportContext _context;

        // Privated use DB in class 
        private readonly DbSet<T> _entitiySet;

        public GenericRepositoryImp(FacilityReportContext context)
        {
            _context = context;
            _entitiySet = _context.Set<T>();
        }

        public T Add(T entity)
        {
            _context.AddAsync(entity);
            return entity;
        }

        public void Remove(T entity)
              => _context.Remove(entity);

        public T Update(T entity)
        {
            _context.Update(entity);
            return entity;
        }
    }
}
