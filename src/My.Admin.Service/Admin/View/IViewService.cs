using My.Admin.Common.Input;
using My.Admin.Common.Output;
using My.Admin.Domain.Admin;
using My.Admin.Service.Admin.View.Input;
using System.Threading.Tasks;

namespace My.Admin.Service.Admin.View
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
        Task<IResponseOutput> GetAsync(long id);

        Task<IResponseOutput> ListAsync(string key);

        Task<IResponseOutput> PageAsync(PageInput<ViewEntity> model);

        Task<IResponseOutput> AddAsync(ViewAddInput input);

        Task<IResponseOutput> UpdateAsync(ViewUpdateInput input);

        Task<IResponseOutput> DeleteAsync(long id);

        Task<IResponseOutput> SoftDeleteAsync(long id);

        Task<IResponseOutput> BatchSoftDeleteAsync(long[] ids);

        Task<IResponseOutput> SyncAsync(ViewSyncInput input);
    }
}