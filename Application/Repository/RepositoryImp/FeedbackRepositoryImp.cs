using Application.IGenericRepository.GeneircRepositoryImp;
using Application.Repository;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.RepositoryImp
{
    public class FeedbackRepositoryImp : GenericRepositoryImp<Feedback>, IFeedbackRepository
    {
        public FeedbackRepositoryImp(FacilityReportContext context) : base(context)
        {
        }

        public async Task<List<Feedback>> GetAll()
        {
            return await _context.Set<Feedback>().Include(c => c.Equipment).Include(c => c.Post).Include(c => c.Account).ToListAsync();
        }

        public async Task<Feedback> GetById(Guid id)
        {

            var feedback = await _context.Set<Feedback>()
                .Include(c => c.Equipment)
                .Include(c => c.Post)
                .Include(c => c.Account)
                .FirstOrDefaultAsync(c => c.FeedBackId == id);
            if (feedback == null)
            {
                throw new Exception("Khong tim thay feedback Id");
            }
            return feedback;
        }
    }
}
