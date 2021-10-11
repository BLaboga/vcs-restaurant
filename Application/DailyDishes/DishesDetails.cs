using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistance;

namespace Application.DailyDishes
{
    public class DishesDetails
    {
        public class Query : IRequest<DailyDish>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, DailyDish>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<DailyDish> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.DailyDishes.FindAsync(request.Id);
            }
        }
    }
}