using System;

namespace YmlTransform.Models
{
    class TransformItem
    {
        private string _value;
        private bool _used;

        public string Path { get; set; }
        public string Type { get; set; }
        public string Languages { get; set; }
        public Guid FieldId { get; set; }

        public string Value
        {
            get
            {
                _used = true;
                return _value;
            }
            set { _value = value; }
        }

        public string Hint { get; set; }

        public bool Used => _used;
    }
}