using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlatform.DataAccess.CQRS.Queries;

namespace TrainingPlatform.DataAccess.CQRS
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly TrainingPlatformContext context;

        public QueryExecutor(TrainingPlatformContext context)
        {
            this.context = context;
        }
        public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
        {
            return query.Execute(this.context);
        }
    }
}
