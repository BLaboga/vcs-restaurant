using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.DailyDishes
{
    public class DishesList
    {
        public class Query : IRequest<List<DailyDish>>
        {

        }
        public class Handler : IRequestHandler<Query, List<DailyDish>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<DailyDish>> Handle(Query request, CancellationToken cancellationToken)
            {
               return await _context.DailyDishes.ToListAsync() ;
            }
        }
    }
}