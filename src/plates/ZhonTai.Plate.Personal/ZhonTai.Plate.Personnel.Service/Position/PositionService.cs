using ZhonTai.Common.Domain.Dto;
using ZhonTai.Plate.Personnel.Service.Position.Input;
using ZhonTai.Plate.Personnel.Service.Position.Output;
using System.Threading.Tasks;
using ZhonTai.Plate.Admin.Service;
using ZhonTai.Plate.Personnel.Domain.Position;
using ZhonTai.Plate.Personnel.Domain.Position.Dto;
using ZhonTai.Tools.DynamicApi;
using ZhonTai.Tools.DynamicApi.Attributes;

namespace ZhonTai.Plate.Personnel.Service.Position
{
    /// <summary>
    /// ְλ����
    /// </summary>
    [DynamicApi(Area = "personnel")]
    public class PositionService : BaseService, IPositionService, IDynamicApi
    {
        private readonly IPositionRepository _positionRepository;

        public PositionService(
            IPositionRepository positionRepository
        )
        {
            _positionRepository = positionRepository;
        }

        /// <summary>
        /// ��ѯְλ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IResultOutput> GetAsync(long id)
        {
            var result = await _positionRepository.GetAsync<PositionGetOutput>(id);
            return ResultOutput.Ok(result);
        }

        /// <summary>
        /// ��ѯ��ҳ
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<IResultOutput> GetPageAsync(PageInput<PositionGetPageDto> input)
        {
            var key = input.Filter?.Name;

            var list = await _positionRepository.Select
            .WhereIf(key.NotNull(), a => a.Name.Contains(key))
            .Count(out var total)
            .OrderByDescending(true, c => c.Id)
            .Page(input.CurrentPage, input.PageSize)
            .ToListAsync<PositionListOutput>();

            var data = new PageOutput<PositionListOutput>()
            {
                List = list,
                Total = total
            };

            return ResultOutput.Ok(data);
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<IResultOutput> AddAsync(PositionAddInput input)
        {
            var entity = Mapper.Map<PositionEntity>(input);
            var id = (await _positionRepository.InsertAsync(entity)).Id;

            return ResultOutput.Result(id > 0);
        }

        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<IResultOutput> UpdateAsync(PositionUpdateInput input)
        {
            if (!(input?.Id > 0))
            {
                return ResultOutput.NotOk();
            }

            var entity = await _positionRepository.GetAsync(input.Id);
            if (!(entity?.Id > 0))
            {
                return ResultOutput.NotOk("ְλ�����ڣ�");
            }

            Mapper.Map(input, entity);
            await _positionRepository.UpdateAsync(entity);
            return ResultOutput.Ok();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IResultOutput> DeleteAsync(long id)
        {
            var result = false;
            if (id > 0)
            {
                result = (await _positionRepository.DeleteAsync(m => m.Id == id)) > 0;
            }

            return ResultOutput.Result(result);
        }

        /// <summary>
        /// ��ɾ��
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task<IResultOutput> SoftDeleteAsync(long id)
        {
            var result = await _positionRepository.SoftDeleteAsync(id);

            return ResultOutput.Result(result);
        }

        /// <summary>
        /// ������ɾ��
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<IResultOutput> BatchSoftDeleteAsync(long[] ids)
        {
            var result = await _positionRepository.SoftDeleteAsync(ids);

            return ResultOutput.Result(result);
        }
    }
}