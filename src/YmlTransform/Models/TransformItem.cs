using System;

namespace YmlTransform.Models
{
    class TransformItem
    {
        public string Path { get; set; }
        public string Type { get; set; }
        public string Languages { get; set; }
        public Guid FieldId { get; set; }
        public string Value { get; set; }
        public string Hint { get; set; }
    }
}