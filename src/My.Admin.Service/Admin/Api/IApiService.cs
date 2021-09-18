using My.Admin.Common.Input;
using My.Admin.Common.Output;
using My.Admin.Domain.Admin;
using My.Admin.Service.Admin.Api.Input;
using System.Threading.Tasks;

namespace My.Admin.Service.Admin.Api
{
    /// <summary>
    /// �ӿڷ���
    /// </summary>
    public interface IApiService
    {
        /// <summary>
        /// ���һ����¼
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IResponseOutput> GetAsync(long id);

        /// <summary>
        /// ����б�
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<IResponseOutput> ListAsync(string key);

        /// <summary>
        /// ��÷�ҳ
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResponseOutput> PageAsync(PageInput<ApiEntity> model);

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<IResponseOutput> AddAsync(ApiAddInput input);

        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<IResponseOutput> UpdateAsync(ApiUpdateInput input);

        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IResponseOutput> DeleteAsync(long id);

        /// <summary>
        /// ��ɾ��
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IResponseOutput> SoftDeleteAsync(long id);

        /// <summary>
        /// ������ɾ��
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<IResponseOutput> BatchSoftDeleteAsync(long[] ids);

        /// <summary>
        /// ͬ��
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<IResponseOutput> SyncAsync(ApiSyncInput input);
    }
}