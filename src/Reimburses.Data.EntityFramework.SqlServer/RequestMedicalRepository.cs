using Data.EntityFramework.SqlServer;
using Reimburses.Data.Abstractions;
using Reimburses.Data.Entities;

namespace Reimburses.Data.EntityFramework.SqlServer
{
    public class RequestMedicalRepository : Repository<RequestMedical>, IRequestMedicalRepository
    {
    }
}
