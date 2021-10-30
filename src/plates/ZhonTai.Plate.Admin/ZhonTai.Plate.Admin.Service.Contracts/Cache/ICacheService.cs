using System.Threading.Tasks;
using ZhonTai.Common.Domain.Dto;

namespace ZhonTai.Plate.Admin.Service.Cache
{
    /// <summary>
    /// �������
    /// </summary>
    public interface ICacheService
    {
        /// <summary>
        /// �����б�
        /// </summary>
        /// <returns></returns>
        IResultOutput GetList();

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        Task<IResultOutput> ClearAsync(string cacheKey);
    }
}