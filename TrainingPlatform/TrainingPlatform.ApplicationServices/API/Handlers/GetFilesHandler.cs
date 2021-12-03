using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingPlatform.ApplicationServices.API.Domain;
using TrainingPlatform.DataAccess;
using TrainingPlatform.DataAccess.Entities;

namespace TrainingPlatform.ApplicationServices.API.Handlers
{
    public class GetFilesHandler : IRequestHandler<GetFilesRequest, GetFilesResponse>
    {
        private readonly IRepository<File> filesRepository;
        private readonly IMapper mapper;

        public GetFilesHandler(IRepository<DataAccess.Entities.File> filesRepository, IMapper mapper)
        {
            this.filesRepository = filesRepository;
            this.mapper = mapper;
        }
        public async Task<GetFilesResponse> Handle(GetFilesRequest request, CancellationToken cancellationToken)
        {
            var files = await this.filesRepository.GetAll();
            var mappedFile = this.mapper.Map<List<Domain.Models.File>>(files);
            var response = new GetFilesResponse() { Data = mappedFile };
            return response;
        }
    }
}