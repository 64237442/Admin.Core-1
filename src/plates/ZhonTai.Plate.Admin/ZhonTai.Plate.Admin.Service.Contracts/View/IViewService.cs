using System.Threading.Tasks;
using ZhonTai.Common.Domain.Dto;
using ZhonTai.Plate.Admin.Domain.View.Dto;
using ZhonTai.Plate.Admin.Service.View.Input;


namespace ZhonTai.Plate.Admin.Service.View
{
    /// <summary>
    /// ��ͼ����
    /// </summary>
    public interface IViewService
    {
        /// <summary>
        /// ���һ����¼
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IResultOutput> GetAsync(long id);

        Task<IResultOutput> GetListAsync(string key);

        Task<IResultOutput> GetPageAsync(PageInput<ViewGetPageDto> model);

        Task<IResultOutput> AddAsync(ViewAddInput input);

        Task<IResultOutput> UpdateAsync(ViewUpdateInput input);

        Task<IResultOutput> DeleteAsync(long id);

        Task<IResultOutput> SoftDeleteAsync(long id);

        Task<IResultOutput> BatchSoftDeleteAsync(long[] ids);

        Task<IResultOutput> SyncAsync(ViewSyncInput input);
    }
}