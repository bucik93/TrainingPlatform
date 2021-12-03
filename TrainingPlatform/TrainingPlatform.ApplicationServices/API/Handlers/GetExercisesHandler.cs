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
    public class GetExercisesHandler : IRequestHandler<GetExercisesRequest, GetExercisesResponse>
    {
        private readonly IRepository<DataAccess.Entities.Exercise> exerciseRepository;
        private readonly IMapper mapper;

        public GetExercisesHandler(IRepository<DataAccess.Entities.Exercise> exerciseRepository, IMapper mapper)
        {
            this.exerciseRepository = exerciseRepository;
            this.mapper = mapper;
        }
        public async Task<GetExercisesResponse> Handle(GetExercisesRequest request, CancellationToken cancellationToken)
        {
            var exercises = await this.exerciseRepository.GetAll();
            var mappedExercise = this.mapper.Map<List<Domain.Models.Exercise>>(exercises);
            var response = new GetExercisesResponse() { Data = mappedExercise };
            return response;
        }
    }
}
