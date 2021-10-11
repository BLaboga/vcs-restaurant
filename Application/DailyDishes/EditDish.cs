using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistance;

namespace Application.DailyDishes
{
    public class EditDish
    {
        public class Command : IRequest
        {
            public DailyDish DailyDish { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var dailyDish = await _context.DailyDishes.FindAsync(request.DailyDish.Id);

                _mapper.Map(request.DailyDish, dailyDish);

                await _context.SaveChangesAsync();
                
                return Unit.Value;
            }



        }

    }
}