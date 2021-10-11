using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistance;

namespace Application.DailyDishes
{
    public class CreateDish
    {
        public class Command : IRequest
        {
            public DailyDish DailyDish { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
               _context.DailyDishes.Add(request.DailyDish);
               
               await _context.SaveChangesAsync();
               return Unit.Value;
            }
        }
    }
}