namespace ZhonTai.Plate.Admin.Service.Document.Dto
{
    public class DocumentUpdateGroupInput : DocumentAddGroupInput
    {
        /// <summary>
        /// ���
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// �汾
        /// </summary>
        public long Version { get; set; }
    }
}