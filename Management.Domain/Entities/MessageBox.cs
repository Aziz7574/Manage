using Management.Domain.Commons;

namespace Management.Domain.Entities
{
    public class MessageBox : Auditable
    {
        public long PartnerId { get; set; }
        public string Text { get; set; }
    }
}
