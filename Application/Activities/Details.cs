using Domain;
using MediatR;
using Persistence;

namespace Application.Activities;
public class Details
{
    public class Query : IRequest<Activity>
    {
        public Guid Id { get; set;}
    }
    public class Handler : IRequestHandler<Query, Activity>
    {
        private readonly DataContext _Context;

        public Handler(DataContext context){
            _Context = context;
        }
        public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _Context.Activities.FindAsync(request.Id);
        }
    }
}