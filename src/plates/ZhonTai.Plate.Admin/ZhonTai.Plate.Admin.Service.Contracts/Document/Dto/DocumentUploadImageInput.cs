using Microsoft.AspNetCore.Http;

namespace ZhonTai.Plate.Admin.Service.Document.Dto
{
    public class DocumentUploadImageInput
    {
        /// <summary>
        /// �ϴ��ļ�
        /// </summary>
        public IFormFile File { get; set; }

        /// <summary>
        /// �ĵ����
        /// </summary>
        public long Id { get; set; }
    }
}