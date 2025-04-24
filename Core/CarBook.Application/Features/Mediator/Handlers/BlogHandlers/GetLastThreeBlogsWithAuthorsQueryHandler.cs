using CarBook.Application.Features.CQRS.Results.CarResult;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetLastThreeBlogsWithAuthorsQueryHandler : 
        IRequestHandler<GetLastThreeBlogsWithAuthorsQuery, List<GetLastThreeBlogsWithAuthorsQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetLastThreeBlogsWithAuthorsQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLastThreeBlogsWithAuthorsQueryResult>> Handle(GetLastThreeBlogsWithAuthorsQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetLastThreeBlogsWithAuthors();
            return values.Select(x => new GetLastThreeBlogsWithAuthorsQueryResult
            {
                AuthorID = x.AuthorID,
                BlogID = x.BlogID,
                CategoryId = x.CategoryId,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate,
                Title = x.Title,
                AuthorName = x.Author.Name
            }).ToList();
        }
    }
}
