using System;

namespace YmlTransform.Models
{
    class TransformItem
    {
        /// <summary>
        /// Path of the item in the tree
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The type of the current item
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The languages of the item
        /// </summary>
        public string Languages { get; set; }

        /// <summary>
        /// The field id
        /// </summary>
        public Guid FieldId { get; set; }

        /// <summary>
        /// The value of the item
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Hint property aka human readable id
        /// </summary>
        public string Hint { get; set; }
    }
}