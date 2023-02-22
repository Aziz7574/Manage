using Management.Domain.Commons;

namespace Management.Domain.Entities
{
    public class MessageBox : Auditable
    {
        public long PartnerId { get; set; }
        public List<string> Text { get; set; }
    }
}
