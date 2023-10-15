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
    public class PostRepositoryImp : GenericRepositoryImp<Post>, IPostRepository
    {
        public PostRepositoryImp(FacilityReportContext context) : base(context)
        {
        }

        public async Task<List<Post>> GetAll()
        {
            return await _context.Set<Post>()
                .Include(c => c.Account)
                .Include(c => c.Feedbacks)
                .Include(c => c.Images)
                .ToListAsync();
        }

        public async Task<Post> GetById(Guid id)
        {
            var post = await _context.Set<Post>()
                 .Include(c => c.Account)
                 .Include(c => c.Feedbacks)
                 .Include(c => c.Images)
                 .FirstOrDefaultAsync(c => c.PostId == id);
            if (post == null)
            {
                throw new Exception("Khong co Post Id");
            }
            return post;
        }
    }
}
