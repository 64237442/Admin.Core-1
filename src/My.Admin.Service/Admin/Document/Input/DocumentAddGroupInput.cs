using My.Admin.Domain.Admin;

namespace My.Admin.Service.Admin.Document.Input
{
    public class DocumentAddGroupInput
    {
        /// <summary>
        /// �����ڵ�
        /// </summary>
        public long ParentId { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public DocumentType Type { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ��
        /// </summary>
        public bool? Opened { get; set; }
    }
}