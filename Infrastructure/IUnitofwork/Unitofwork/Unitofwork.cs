using Application.Repository;
using Application.Repository.RepositoryImp;
using Domain.Entity;

namespace Infrastructure.IUnitofwork.Unitofwork
{
    public class Unitofwork : IUnitofWork
    {
        private readonly FacilityReportContext _context;
        private readonly ITaskRepository _taskRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IEquiptmentRepository _equipmentRepository;
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IHistoryEquipmentRepository
            _historyEquipmentRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IResourceRepository _resourceRepository;

        public Unitofwork(FacilityReportContext context)
        {
            _context = context;
            _accountRepository = new AccountRepositoryImp(context);
            _equipmentRepository = new EquiptmentRepositoryImp(context);
            _taskRepository = new TaskRepositoryImp(context);
            _imageRepository = new ImageRepositoryImp(context);
            _resourceRepository = new ResourceRepositoryImp(context);
            _historyEquipmentRepository = new HistoryEquipmentRepositoryImp(context);
            _feedbackRepository = new FeedbackRepositoryImp(context);
        }

        public IAccountRepository Account => _accountRepository;

        public IEquiptmentRepository Equiptment => _equipmentRepository;

        public IFeedbackRepository Feedback => _feedbackRepository;

        public IHistoryEquipmentRepository HistoryEquipment => _historyEquipmentRepository;

        public IImageRepository Image => _imageRepository;


        public IResourceRepository Resource => _resourceRepository;

        public ITaskRepository Task => _taskRepository;

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
