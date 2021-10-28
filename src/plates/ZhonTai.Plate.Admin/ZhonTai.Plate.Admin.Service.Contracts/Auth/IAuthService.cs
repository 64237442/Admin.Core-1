using ZhonTai.Common.Domain.Dto;
using System.Threading.Tasks;
using ZhonTai.Plate.Admin.Service.Auth.Input;

namespace ZhonTai.Plate.Admin.Service.Auth
{
    /// <summary>
    /// Ȩ�޷���
    /// </summary>
    public interface IAuthService
    {
        Task<IResponseOutput> LoginAsync(AuthLoginInput input);

        Task<IResponseOutput> GetUserInfoAsync();

        Task<IResponseOutput> GetVerifyCodeAsync(string lastKey);

        Task<IResponseOutput> GetPassWordEncryptKeyAsync();
    }
}