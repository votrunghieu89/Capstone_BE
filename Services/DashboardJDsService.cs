using Capstone.Database;
using Capstone.Repositories.Dashboard;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Capstone.Services
{
    public class DashboardJDsService : IDashboardJDsRepository
    {
        public readonly AppDbContext _dbContext;
        public readonly ILogger<DashboardJDsService> _logger;
        public DashboardJDsService(AppDbContext dbContext , ILogger<DashboardJDsService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;   
        }
        public async Task<int> GetTotalCreateJD()
        {
            bool connection = _dbContext.Database.CanConnect();
            if (!connection)
            {
                _logger.LogError("Can not connect server");
                return 0;
            }
            try
            {
                int totalJD = await _dbContext.jDsModel.CountAsync();
                return totalJD;
            }
            catch (Exception ex)
            {
                
                _logger.LogError(ex, "Error getting total JD create");                    
                return 0;
              
            }         
        }

        public async Task<int> GetTotalCreateJDByMonth(int month)
        {
            bool connection = _dbContext.Database.CanConnect();
            if (!connection)
            {
                _logger.LogError("Can not connect server");
                return 0;
            }
            try
            {
                int totalJDbyM = await _dbContext.jDsModel.Where(jd => jd.CreatedAt.Month == month).CountAsync();
                return totalJDbyM;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting total JD create by Month ");
                return 0;
            }
        }
    }
}
