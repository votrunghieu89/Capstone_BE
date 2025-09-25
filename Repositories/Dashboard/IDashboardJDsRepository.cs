namespace Capstone.Repositories.Dashboard
{
    public interface IDashboardJDsRepository
    {
        // Hiển thị tổng JD đã dc tạo
        Task<int> GetTotalCreateJD();

        // Hiển thị tổng JD đã dc tạo trong tháng
        Task<int> GetTotalCreateJDByMonth(int month);
        
        // Hiển thị JD dc apply nhiều nhất
    }
}
