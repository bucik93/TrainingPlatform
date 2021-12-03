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
    public class GetContentFilesHandler : IRequestHandler<GetContentFilesRequest, GetContentFilesResponse>
    {
        private readonly IRepository<ContentFile> contentFileRepository;
        private readonly IMapper mapper;

        public GetContentFilesHandler(IRepository<DataAccess.Entities.ContentFile> contentFileRepository, IMapper mapper)
        {
            this.contentFileRepository = contentFileRepository;
            this.mapper = mapper;
        }
        public async Task<GetContentFilesResponse> Handle(GetContentFilesRequest request, CancellationToken cancellationToken)
        {
            var contentFiles = await this.contentFileRepository.GetAll();
            var mappedContentFile = this.mapper.Map<List<Domain.Models.ContentFile>>(contentFiles);
            var response = new GetContentFilesResponse() { Data = mappedContentFile };
            return response;
        }
    }
}